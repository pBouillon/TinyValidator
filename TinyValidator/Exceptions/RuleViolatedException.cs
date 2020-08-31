/*
 * Author
 *      Pierre Bouillon - https://github.com/pBouillon
 *
 * Repository
 *      TinyValidator - https://github.com/pBouillon/TinyValidator
 *
 * License
 *      MIT - https://github.com/pBouillon/TinyValidator/blob/master/LICENSE
 */

using System;
using TinyValidator.Abstractions;

namespace TinyValidator.Exceptions
{
    /// <summary>
    /// Default exception thrown when a <see cref="Rule{T}"/> is not validated
    /// </summary>
    public class RuleViolatedException : Exception
    {
        /// <summary>
        /// Parameter-less constructor
        /// </summary>
        public RuleViolatedException() { }

        /// <summary>
        /// Create the exception with a specific message
        /// </summary>
        /// <param name="message">Custom exception message</param>
        public RuleViolatedException(string message) 
            : base(message) { }
    }
}
