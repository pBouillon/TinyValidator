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

namespace TinyValidator.Abstractions
{
    /// <summary>
    /// Represent a unique rule to be validated by the <see cref="IValidator{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of the value to be validated</typeparam>
    public abstract class Rule<T>
    {
        /// <summary>
        /// Check if the value is valid in its case
        /// </summary>
        /// <returns>True if the rule is respected; false otherwise</returns>
        protected abstract bool IsValidWhen(T value);

        /// <summary>
        /// Logic to be executed if <see cref="IsValidWhen"/> fails
        /// </summary>
        protected abstract void OnInvalid();

        /// <summary>
        /// Perform the effective validation
        /// </summary>
        /// <param name="value">Value to be validated</param>
        public void Validate(T value)
        {
            if (!IsValidWhen(value))
            {
                OnInvalid();
            }
        }
    }
}
