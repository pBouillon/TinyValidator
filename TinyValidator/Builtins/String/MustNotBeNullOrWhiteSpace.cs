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

namespace TinyValidator.Builtins.Strings
{
    /// <summary>
    /// <see cref="Rule{T}"/> to ensure that a string is not nul nor white spaces
    /// </summary>
    public class MustNotBeNullOrWhiteSpace : StringRule
    {
        /// <inheritdoc cref="Rule{T}.IsValidWhen"/>
        protected override bool IsValidWhen(string value)
            => !string.IsNullOrWhiteSpace(value);

        /// <inheritdoc cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException(
                $"{nameof(MustNotBeNullOrWhiteSpace)}: Expected the provided string not to be null or only " +
                "white spaces");
    }
}
