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

namespace TinyValidator.Builtins.String
{
    /// <summary>
    /// Specialized <see cref="Rule{T}"/> for string validation
    /// </summary>
    public abstract class StringRule : Rule<string> { }
}
