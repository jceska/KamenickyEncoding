using System;
using System.Text;
using Keybcs2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KamenickyEncoding.UnitTests
{
    [TestClass]
    public class Keybcs2EncodingProviderTest
    {
        public Keybcs2EncodingProviderTest()
        {
            // Register the custom provider at the start of the test suite
            Keybcs2EncodingProvider.Register();
        }

        [TestMethod]
        public void GetEncoding_BySupportedNames_ShouldReturnKeybcs2Instance()
        {
            // Arrange
            var provider = new Keybcs2EncodingProvider();
            string[] supportedNames = { "keybcs2", "kamenicky", "kamenicky895" };

            foreach (var name in supportedNames)
            {
                // Act
                var encoding = provider.GetEncoding(name);

                // Assert
                Assert.IsNotNull(encoding, $"Encoding for name '{name}' should be supported.");
                Assert.IsInstanceOfType(encoding, typeof(Keybcs2Encoding), $"Name '{name}' should return Keybcs2Encoding instance.");
            }
        }

        [TestMethod]
        public void GetEncoding_ByInvalidCodePage_ShouldReturnNull()
        {
            // Arrange
            var provider = new Keybcs2EncodingProvider();

            // Act
            // If 895 is not implemented in your GetEncoding(int), it should return null
            var encoding = provider.GetEncoding(895);

            // Assert
            Assert.IsNull(encoding, "Provider should return null for codepage 895 if it's not explicitly supported.");
        }

        [TestMethod]
        public void GetEncoding_ByUnknownName_ShouldReturnNull()
        {
            // Arrange
            var provider = new Keybcs2EncodingProvider();

            // Act
            var encoding = provider.GetEncoding("unknown-encoding-name");

            // Assert
            Assert.IsNull(encoding, "Provider should return null for an unsupported encoding name.");
        }

        [TestMethod]
        public void EncodingGetEncoding_AfterRegistration_ShouldFindKeybcs2()
        {
            // Act
            // This tests the static Register() method and integration with .NET Encoding system
            var encoding = Encoding.GetEncoding("keybcs2");

            // Assert
            Assert.IsNotNull(encoding, "Encoding.GetEncoding should find 'keybcs2' after provider registration.");
            Assert.IsInstanceOfType(encoding, typeof(Keybcs2Encoding));
        }
    }
}