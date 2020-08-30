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
using System.Linq;
using TinyValidator.Abstractions;

namespace TinyValidator
{
    /// <summary>
    /// Concrete implementation of <see cref="IValidator{T}"/> 
    /// </summary>
    /// <inheritdoc cref="IValidator{T}"/>
    public class Validator<T> : IValidator<T>
    {
        /// <inheritdoc cref="IValidator{T}.Rules"/>
        public IEnumerable<Rule<T>> Rules { get; }

        /// <summary>
        /// Create a new validator with its set of rules
        /// </summary>
        /// <param name="rules">Rules to be validated</param>
        private Validator(IEnumerable<Rule<T>> rules)
            => Rules = rules;

        /// <summary>
        /// Create a new validator with a set of rules to be executed in the
        /// provided order
        /// </summary>
        /// <param name="rules">Rules to be validated</param>
        /// <returns>A new instance of <see cref="Validator{T}"/></returns>
        public static Validator<T> CreateValidationPipelineWith(params Rule<T>[] rules)
            => new Validator<T>(rules.ToList());

        /// <summary>
        /// Create a new validator with a set of rules to be executed in the
        /// provided order
        /// </summary>
        /// <param name="rules">Rules to be validated</param>
        /// <returns>A new instance of <see cref="Validator{T}"/></returns>
        public static Validator<T> CreateValidationPipelineWith(IEnumerable<Rule<T>> rules)
            => new Validator<T>(rules);

        /// <inheritdoc cref="IValidator{T}.Clone"/>
        public IValidator<T> Clone()
            => CreateValidationPipelineWith(Rules);

        /// <inheritdoc cref="IValidator{T}.Validate"/>
        public void Validate(T value)
            => Rules.ToList()
                .ForEach(rule =>
                    rule.Validate(value));
    }
}
