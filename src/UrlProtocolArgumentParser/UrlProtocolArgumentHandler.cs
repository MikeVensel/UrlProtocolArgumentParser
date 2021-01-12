namespace UrlProtocolArgumentParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Handles parsing a url protocol handler url.
    /// </summary>
    public class UrlProtocolArgumentHandler
    {
        private readonly List<QueryParameterArgument> arguments;

        private readonly Func<QueryParameterArgument, bool> condition;

        private readonly Dictionary<string, string> queryParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlProtocolArgumentHandler"/> class.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <param name="condition">Condition which determines if the handler will run on this url.</param>
        public UrlProtocolArgumentHandler(string url, Func<QueryParameterArgument, bool> condition)
        {
            this.condition = condition;
            this.arguments = new List<QueryParameterArgument>();
            this.queryParameters = new Dictionary<string, string>();
            url = Regex.Replace(url, @".*:\/\/", string.Empty);
            var queryParameterValues = url.Split('&');

            foreach (var param in queryParameterValues)
            {
                var nameVal = param.Split('=');
                if (nameVal.Length != 2)
                {
                    throw new QueryStringFormatException($"The query string parameter {param} is not in the proper format.");
                }

                this.queryParameters.Add(nameVal[0], nameVal[1]);
            }
        }

        /// <summary>
        /// Gets or sets the handler to be run.
        /// </summary>
        public CommandHandler Handler { get; set; }

        /// <summary>
        /// Adds a new argument.
        /// </summary>
        /// <param name="argument">An argument object.</param>
        public void Add(QueryParameterArgument argument)
        {
            this.arguments.Add(argument);
        }

        /// <summary>
        /// Adds a new argument.
        /// </summary>
        /// <param name="queryParameter">The query string parameter name.</param>
        public void Add(string queryParameter)
        {
            var argument = new QueryParameterArgument(queryParameter);
            if (this.queryParameters.TryGetValue(queryParameter, out var paramValue))
            {
                argument.Value = paramValue;
            }
            else
            {
                argument.Value = string.Empty;
            }

            this.arguments.Add(argument);
        }

        /// <summary>
        /// Adds a new argument.
        /// </summary>
        /// <param name="queryParameter">The query string parameter name.</param>
        /// <typeparam name="T">The expected type of the query string parameter value.</typeparam>
        public void Add<T>(string queryParameter)
        {
            var argument = new QueryParameterArgument(queryParameter);
            if (this.queryParameters.TryGetValue(queryParameter, out var paramValue))
            {
                var decodedParam = WebUtility.UrlDecode(paramValue);
                argument.Value = JsonSerializer.Deserialize<T>(decodedParam);
            }
            else
            {
                argument.Value = default(T);
            }

            this.arguments.Add(argument);
        }

        /// <summary>
        /// Runs the provided <see cref="Handler"/> if the provided condition is met.
        /// </summary>
        public void Run()
        {
            if (this.arguments.Any(this.condition))
            {
                var argValues = this.GetArgValues(this.Handler.MethodInfo.GetParameters());
                this.Handler.Invoke(argValues);
            }
        }

        private object[] GetArgValues(ParameterInfo[] paramInfo)
        {
            var argValueList = new List<object>();
            foreach (var param in paramInfo)
            {
                var argument = this.arguments.FirstOrDefault(x => x.Name == param.Name);

                if (argument == null)
                {
                    argValueList.Add(null);
                }
                else
                {
                    argValueList.Add(argument.Value);
                }
            }

            return argValueList.ToArray();
        }
    }
}