namespace UrlProtocolArgumentParser
{
    using System;
    using System.Reflection;

    /// <summary>
    /// A class used to store action method information for use in the handlers.
    /// </summary>
    public class UrlProtocolCommandHandler
    {
        private object target;

        /// <summary>
        /// Gets or sets method info.
        /// </summary>
        public MethodInfo MethodInfo { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">Action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T>(Action<T> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2>(Action<T1, T2> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <typeparam name="T5">Fifth action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <typeparam name="T5">Fifth action parameter type.</typeparam>
        /// <typeparam name="T6">Sixth action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <typeparam name="T5">Fifth action parameter type.</typeparam>
        /// <typeparam name="T6">Sixth action parameter type.</typeparam>
        /// <typeparam name="T7">Seventh action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <typeparam name="T5">Fifth action parameter type.</typeparam>
        /// <typeparam name="T6">Sixth action parameter type.</typeparam>
        /// <typeparam name="T7">Seventh action parameter type.</typeparam>
        /// <typeparam name="T8">Eighth action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="UrlProtocolCommandHandler"/> that represents the provided action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T1">First action parameter type.</typeparam>
        /// <typeparam name="T2">Second action parameter type.</typeparam>
        /// <typeparam name="T3">Third action parameter type.</typeparam>
        /// <typeparam name="T4">Fourth action parameter type.</typeparam>
        /// <typeparam name="T5">Fifth action parameter type.</typeparam>
        /// <typeparam name="T6">Sixth action parameter type.</typeparam>
        /// <typeparam name="T7">Seventh action parameter type.</typeparam>
        /// <typeparam name="T8">Eighth action parameter type.</typeparam>
        /// <typeparam name="T9">Ninth action parameter type.</typeparam>
        /// <returns>
        /// An instance of <see cref="UrlProtocolCommandHandler"/>.
        /// </returns>
        public static UrlProtocolCommandHandler CreateHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            return new UrlProtocolCommandHandler
            {
                MethodInfo = action.Method,
                target = action.Target,
            };
        }

        /// <summary>
        /// Invokes the provided action.
        /// </summary>
        /// <param name="args">Arguments to be passed to the action.</param>
        public void Invoke(object[] args) => this.MethodInfo.Invoke(this.target, args);
    }
}