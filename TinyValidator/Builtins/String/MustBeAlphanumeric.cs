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

using System.Linq;
using TinyValidator.Abstractions;
using TinyValidator.Exceptions;

namespace TinyValidator.Builtins.String
{
    /// <summary>
    /// <see cref="Rule{T}"/> to ensure that a string is only made of alphanumeric characters
    /// </summary>
    public class MustBeAlphanumeric : StringRule
    {
        /// <inheritdoc cref="Rule{T}.IsValidWhen"/>
        protected override bool IsValidWhen(string value)
            => value.All(char.IsLetterOrDigit);

        /// <inheritdoc cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException(
                $"{nameof(MustNotBeNullOrEmpty)}: Expected the provided string to be alphanumeric");
    }
}
