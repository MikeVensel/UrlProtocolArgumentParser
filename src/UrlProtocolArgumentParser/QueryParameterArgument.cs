namespace UrlProtocolArgumentParser
{
    using System;

    /// <summary>
    /// Holds a query string parameter.
    /// </summary>
    public class QueryParameterArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterArgument"/> class.
        /// </summary>
        /// <param name="queryParameter">The name of the query parameter.</param>
        public QueryParameterArgument(string queryParameter)
        {
            this.Name = queryParameter;
        }

        /// <summary>
        /// Gets or sets the name of the query parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Value of the query parameter.
        /// </summary>
        public object Value { get; set; }
    }
}