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
    /// <see cref="Rule{T}"/> to ensure that a string is shorter than
    /// a given limit
    /// </summary>
    public class MustBeShorterThan : StringRule
    {
        private readonly int _limit;

        /// <inheritdoc cref="Rule{T}.IsValidWhen"/>
        public MustBeShorterThan(int limit)
            => _limit = limit;

        protected override bool IsValidWhen(string value)
            => value.Length < _limit;

        /// <inheritdoc cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException(
                $"{nameof(MustBeShorterThan)}: Expected the provided string to be shorter than ${_limit}");
    }
}
