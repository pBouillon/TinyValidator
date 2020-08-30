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
    /// <see cref="Rule{T}"/> to ensure that a string is not empty
    /// </summary>
    public class MustNotBeEmpty : StringRule
    {
        /// <inheritdoc cref="Rule{T}.IsValidWhen"/>
        protected override bool IsValidWhen(string value)
            => value.Length > 0;

        /// <inheritdoc cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException(
                $"{nameof(MustNotBeEmpty)}: Expected the provided string not to be empty");
    }
}
