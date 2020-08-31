using AutoFixture;
using FluentAssertions;
using System;
using System.Linq;
using TinyValidator.Exceptions;
using TinyValidator.UnitTests.Common;
using Xunit;

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

namespace TinyValidator.UnitTests.TinyValidator
{
    /// <summary>
    /// Unit tests to ensure the behaviour of <see cref="Validator{T}"/>
    /// </summary>
    public class ValidatorUnitTests
    {
        /// <summary>
        /// Private instance of <see cref="IFixture"/> for test data generation purposes
        /// </summary>
        private readonly IFixture _fixture = new Fixture();

        /// <summary>
        /// Ensure that the validation pipeline is correctly created
        /// </summary>
        [Fact]
        public void Validator_FromValidationPipeline()
        {
            // Arrange
            var rules = _fixture.CreateMany<DummyRule>()
                .ToList();

            // Act
            var validator = Validator<bool>.FromValidationPipeline(rules);

            // Assert
            validator.Rules
                .Should()
                .ContainInOrder(rules,
                    "because all rules used on creation should be held by the validator");
        }

        /// <summary>
        /// Ensure that a successful validation does not trigger the failure handler
        /// </summary>
        [Fact]
        public void Validator_ValidateNotThrowWhenValid()
        {
            // Arrange
            const bool value = true;
            var validator = Validator<bool>.FromValidationPipeline(
                new DummyRule());

            // Act
            Action validatingAValidValidValue = () 
                => validator.Validate(value);

            // Assert
            validatingAValidValidValue.Should()
                .NotThrow<RuleViolatedException>(
                    "because no exception should be thrown when the validation is successful");
        }

        /// <summary>
        /// Ensure that a failing validation trigger the failure handler
        /// </summary>
        [Fact]
        public void Validator_ValidateThrowWhenNotValid()
        {
            // Arrange
            const bool value = false;
            var validator = Validator<bool>.FromValidationPipeline(
                new DummyRule());

            // Act
            Action validatingAValidValidValue = ()
                => validator.Validate(value);

            // Assert
            validatingAValidValidValue.Should()
                .Throw<RuleViolatedException>(
                    "because the exception should be thrown when the validation fails");
        }
    }
}
