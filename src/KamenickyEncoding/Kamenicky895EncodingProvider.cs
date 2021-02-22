namespace KamenickyEncoding
{
    using System;
    using System.Text;

    public class Kamenicky895EncodingProvider : EncodingProvider
    {
        public Kamenicky895Encoding Kamenicky895Encoding = new Kamenicky895Encoding();

        public override Encoding GetEncoding(int codepage)
            => codepage == Kamenicky895Encoding.CodePage 
                ? Kamenicky895Encoding 
                : null;

        public override Encoding GetEncoding(string name) 
            => Kamenicky895Encoding.HeaderName.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                ? Kamenicky895Encoding
                : null;
    }
}