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

using System.Collections.Generic;

namespace TinyValidator.Abstractions
{
    /// <summary>
    /// Represent a validation chain's entry point
    /// </summary>
    /// <typeparam name="T">Type of the value to be validated</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Set of rules to check against the provided value
        /// </summary>
        IEnumerable<Rule<T>> Rules { get; }

        /// <summary>
        /// Clone the current instance of the <see cref="IValidator{T}"/>
        /// </summary>
        /// <returns>A clone of the instance, holding the same <see cref="Rules"/></returns>
        IValidator<T> Clone();

        /// <summary>
        /// Effective call to validate each of the previously provided rules
        /// </summary>
        /// <param name="value">Value to be validated</param>
        void Validate(T value);
    }
}
