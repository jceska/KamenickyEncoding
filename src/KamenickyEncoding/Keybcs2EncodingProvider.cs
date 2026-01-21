namespace Keybcs2
{
    using Keybcs2;
    using System;
    using System.Text;

    public class Keybcs2EncodingProvider : EncodingProvider
    {
        private static readonly Keybcs2Encoding _instance = new Keybcs2Encoding();
        public override Encoding GetEncoding(int codepage) => null;
        public override Encoding GetEncoding(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            name = name.ToLowerInvariant();
            return (name == "keybcs2" || name == "kamenicky" || name == "kamenicky895") ? _instance : null;
        }
        public static void Register() => Encoding.RegisterProvider(new Keybcs2EncodingProvider());
    }
}