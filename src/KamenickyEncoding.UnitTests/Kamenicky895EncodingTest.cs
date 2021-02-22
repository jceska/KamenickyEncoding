namespace KamenickyEncoding.UniTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Kamenicky895EncodingTest
    {
        byte[] Sample895 
            => File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Fixtures", "Sample895.txt"));


        byte[] SampleUtf
            => File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Fixtures", "SampleUtf8.txt"));

        public Kamenicky895EncodingTest() 
            => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        [TestMethod]
        public void Encoding895Convert()
        {
            var encoding = new Kamenicky895Encoding();
            var encoding895Chars = encoding.GetChars(Sample895);
            var encodingUtfChars = Encoding.UTF8.GetChars(SampleUtf);

            Assert.IsTrue(encoding895Chars.SequenceEqual(encodingUtfChars));
        }

        [TestMethod]
        public void TestGetBytes()
        {
            var encoding = new Kamenicky895Encoding();
            var chars = encoding.GetChars(Sample895);

            var bytes = encoding.GetBytes(chars, 0, chars.Length);

            Assert.IsTrue(Sample895.SequenceEqual(bytes));
        }
    }
}