namespace Keybcs2
{    
    using System.Text;

    public class Keybcs2Encoding : Encoding
    {
        public override string BodyName => "keybcs2";
        public override string HeaderName => "keybcs2";
        public override string EncodingName => "Kamenicky (KEYBCS2)";
        public override string WebName => "keybcs2";
        public override int CodePage => 0;

        public override int GetByteCount(char[] chars, int index, int count) => count;
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            for (int i = 0; i < charCount; i++)
                bytes[byteIndex + i] = CharMapping.ToByte[chars[charIndex + i]];
            return charCount;
        }
        public override int GetCharCount(byte[] bytes, int index, int count) => count;
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            for (int i = 0; i < byteCount; i++)
                chars[charIndex + i] = CharMapping.ToChar[bytes[byteIndex + i]];
            return byteCount;
        }
        public override int GetMaxByteCount(int charCount) => charCount;
        public override int GetMaxCharCount(int byteCount) => byteCount;
    }
}
