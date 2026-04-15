using Shouldly;
using Xunit;

namespace PayNLSdk.Tests.Api.Alliance
{
    public class AddBankAccountRequestTests
    {
        [Fact]
        public void GetParameters_ReturnsMandatoryParameters()
        {
            // Arrange
            var sut = new PAYNLSDK.API.Alliance.AddBankAccount.Request("M-1", "https://merchant.example/return");

            // Act
            var parameters = sut.GetParameters();

            // Assert
            parameters["merchantId"].ShouldBe("M-1");
            parameters["returnUrl"].ShouldBe("https://merchant.example/return");
        }

        [Fact]
        public void GetParameters_DoesNotIncludeOptionalParameters_WhenNotSet()
        {
            // Arrange
            var sut = new PAYNLSDK.API.Alliance.AddBankAccount.Request("M-1", "https://merchant.example/return");

            // Act
            var parameters = sut.GetParameters();

            // Assert
            parameters["bankId"].ShouldBeNull();
            parameters["paymentOptionId"].ShouldBeNull();
        }

        [Fact]
        public void GetParameters_IncludesOptionalParameters_WhenSet()
        {
            // Arrange
            var sut = new PAYNLSDK.API.Alliance.AddBankAccount.Request("M-1", "https://merchant.example/return")
            {
                BankId = 26462,
                PaymentOptionId = 6104
            };

            // Act
            var parameters = sut.GetParameters();

            // Assert
            parameters["bankId"].ShouldBe("26462");
            parameters["paymentOptionId"].ShouldBe("6104");
        }
    }
}
