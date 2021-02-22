namespace KamenickyEncoding.UniTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Kamenicky895EncodingProviderTest
    {
        public Kamenicky895EncodingProviderTest()
            => System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        [TestMethod]
        public void ShouldReturnEncodingForCodePage895()
        {
            var encodingProvider = new Kamenicky895EncodingProvider();

            var encoding = encodingProvider.GetEncoding(895);

            Assert.IsNotNull(encoding);
            Assert.AreEqual(typeof(Kamenicky895Encoding), encoding.GetType());
        }

        [TestMethod]
        public void ShouldNotReturnEncodingForUnknownCodePage()
        {
            var encodingProvider = new Kamenicky895EncodingProvider();

            var encoding = encodingProvider.GetEncoding(Int32.MaxValue);

            Assert.IsNull(encoding);
        }

        [TestMethod]
        public void ShouldReturnEncodingKamenickyEncodingName()
        {
            var encodingProvider = new Kamenicky895EncodingProvider();

            var encoding = encodingProvider.GetEncoding("kamenicky895");

            Assert.IsNotNull(encoding);
            Assert.AreEqual(typeof(Kamenicky895Encoding), encoding.GetType());
        }

        [TestMethod]
        public void ShouldReturnEncodingUknownEncodingName()
        {
            var encodingProvider = new Kamenicky895EncodingProvider();

            var encoding = encodingProvider.GetEncoding("uknown");

            Assert.IsNull(encoding);
        }
    }
}