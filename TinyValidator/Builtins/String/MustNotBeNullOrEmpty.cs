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

using TinyValidator.Abstractions;
using TinyValidator.Exceptions;

namespace TinyValidator.Builtins.String
{
    /// <summary>
    /// <see cref="Rule{T}"/> to ensure that a string is not null nor empty
    /// </summary>
    public class MustNotBeNullOrEmpty : StringRule
    {
        /// <inheritdoc cref="Rule{T}.IsValidWhen"/>
        protected override bool IsValidWhen(string value)
            => !string.IsNullOrEmpty(value);

        /// <inheritdoc cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException(
                $"{nameof(MustNotBeNullOrEmpty)}: Expected the provided string not to be null or empty");
    }
}
