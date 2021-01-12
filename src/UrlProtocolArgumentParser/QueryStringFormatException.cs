namespace UrlProtocolArgumentParser
{
    using System;

    /// <summary>
    /// Exception used to describe any issue with the formatting of a query string parameter.
    /// </summary>
    public class QueryStringFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringFormatException"/> class.
        /// </summary>
        public QueryStringFormatException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringFormatException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public QueryStringFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringFormatException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public QueryStringFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}