using System;
using System.IO;
using System.Linq;
using System.Text;
using Keybcs2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keybcs2.UnitTests
{
    [TestClass]
    public class Keybcs2EncodingTest
    {
        private static readonly string FixturesPath = Path.Combine(AppContext.BaseDirectory, "Fixtures");

        // Static byte arrays to avoid repeated file I/O during test execution
        private static readonly byte[] SampleKeybcs2 = File.ReadAllBytes(Path.Combine(FixturesPath, "Sample895.txt"));
        private static readonly byte[] SampleUtf8 = File.ReadAllBytes(Path.Combine(FixturesPath, "SampleUtf8.txt"));

        public Keybcs2EncodingTest()
        {
            // Ensure the custom provider is registered before running tests
            Keybcs2EncodingProvider.Register();
        }

        [TestMethod]
        public void Decode_KamenickyBytesToUtf8String_ShouldMatchExpectedOutput()
        {
            // Arrange
            var encoding = new Keybcs2Encoding();

            // Act
            string actualResult = encoding.GetString(SampleKeybcs2);
            string expectedResult = Encoding.UTF8.GetString(SampleUtf8);

            // Assert
            // Assert.AreEqual provides a detailed diff in case of failure
            Assert.AreEqual(expectedResult, actualResult, "The decoded string does not match the expected UTF-8 reference.");
        }

        [TestMethod]
        public void Encode_Utf8StringToKamenickyBytes_ShouldMatchOriginalBytes()
        {
            // Arrange
            var encoding = new Keybcs2Encoding();
            string inputSource = Encoding.UTF8.GetString(SampleUtf8);

            // Act
            byte[] actualBytes = encoding.GetBytes(inputSource);            

            // Assert
            CollectionAssert.AreEqual(SampleKeybcs2, actualBytes, "The encoded byte array does not match the original Kamenicky source.");
        }

        [TestMethod]
        public void GetMaxByteCount_ShouldReturnInputCount()
        {
            // Arrange
            var encoding = new Keybcs2Encoding();
            const int inputCount = 128;

            // Act & Assert
            Assert.AreEqual(inputCount, encoding.GetMaxByteCount(inputCount), "MaxByteCount should be 1:1 for this encoding.");
        }

        [TestMethod]
        public void GetMaxCharCount_ShouldReturnInputCount()
        {
            // Arrange
            var encoding = new Keybcs2Encoding();
            const int inputCount = 256;

            // Act & Assert
            Assert.AreEqual(inputCount, encoding.GetMaxCharCount(inputCount), "MaxCharCount should be 1:1 for this encoding.");
        }
    }
}