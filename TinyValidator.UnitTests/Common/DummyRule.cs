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

namespace TinyValidator.UnitTests.Common
{
    /// <summary>
    /// Dummy rule for test purpose, is valid when the provided is <c>true</c>
    /// </summary>
    /// <see cref="Rule{T}"/>
    public class DummyRule : Rule<bool>
    {
        /// <see cref="Rule{T}.IsValidWhen"/>
        protected override bool IsValidWhen(bool value)
            => value;

        /// <see cref="Rule{T}.OnInvalid"/>
        protected override void OnInvalid()
            => throw new RuleViolatedException();
    }
}
