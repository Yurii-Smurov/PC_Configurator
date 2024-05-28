using Configurator.Services.RegistrationService.Validators;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ConfiguratorTests
{
    [TestFixture]
    public class PasswordValidatorTest
    {
        private PasswordValidator _passwordValidator;

        [SetUp]
        public void Setup()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Test]
        public void Validate_WhenPasswordIsValid_ShouldReturnTrue()
        {
            // Arrange
            var validPassword = "TestPassword123.";

            // Act
            var result = _passwordValidator.Validate(validPassword);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void Validate_WhenPasswordIsTooShort_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "test";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordIsTooLong_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "thispasswordiswaytoolongandexceedsthecharacterlimit";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordLacksNumber_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "TestPassword123";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordLacksUpperChar_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "testpassword123";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordLacksLowerChar_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "TESTPASSWORD123";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordLacksSymbols_ShouldReturnFalse()
        {
            // Arrange
            var invalidPassword = "TestPassword123";

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void Validate_WhenPasswordIsNull_ShouldReturnFalse()
        {
            // Arrange
            string? invalidPassword = null;

            // Act
            var result = _passwordValidator.Validate(invalidPassword);

            // Assert
            ClassicAssert.IsFalse(result);
        }
    }
    
}
