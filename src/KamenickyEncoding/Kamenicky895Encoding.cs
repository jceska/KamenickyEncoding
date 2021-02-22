namespace KamenickyEncoding
{
    using System.Text;

    public class Kamenicky895Encoding : Encoding
    {
        readonly Encoding ibm437Encoding = CodePagesEncodingProvider.Instance.GetEncoding(437);

        public override string BodyName => "kamenicky895";
        
        public override int CodePage => 895;
        
        public override string HeaderName => "kamenicky895";
        
        public override string EncodingName => "Kamenicky 895";
        
        public override string WebName => "kamenicky895";
        
        public override int GetByteCount(char[] chars, int index, int count) 
            => chars.Length;

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            var byteCount = ibm437Encoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);

            for (var i = 0; i < charCount; i++)
            {
                var sourceChar = chars[charIndex + i];

                if (CharMapping.CodePage895To437CharMapping.TryGetValue(sourceChar, out var convertedByte))
                {
                    bytes[byteIndex + i] = convertedByte;
                }
            }

            return byteCount;
        }

        public override int GetCharCount(byte[] bytes, int index, int count) 
            => bytes.Length;

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            var charsCount = ibm437Encoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);

            for (var i = 0; i < byteCount; i++)
            {
                var sourceByte = bytes[byteIndex + i];

                if (CharMapping.CodePage895To437ByteMapping.TryGetValue(sourceByte, out var convertedChar))
                {
                    chars[charIndex + i] = convertedChar;
                }
            }

            return charsCount;
        }

        public override int GetMaxByteCount(int charCount) 
            => charCount;

        public override int GetMaxCharCount(int byteCount) 
            => byteCount;
    }
}
