﻿namespace KamenickyEncoding
{
    using System.Collections.Generic;

    public class CharMapping
    {
        static readonly Dictionary<byte, char> ByteMappingDictionary = new Dictionary<byte, char>
        {
            { 136, 'ě'},
            { 150, 'ů'},
            { 152, 'ý'},
            { 135, 'č'},
            { 131, 'ď'},
            { 141, 'ĺ'},
            { 140, 'ľ'},
            { 164, 'ň'},
            { 170, 'ŕ'},
            { 169, 'ř'},
            { 168, 'š'},
            { 159, 'ť'},
            { 145, 'ž'},
            { 143, 'Á'},
            { 137, 'Ě'},
            { 139, 'Í'},
            { 149, 'Ó'},
            { 167, 'Ô'},
            { 151, 'Ú'},
            { 166, 'Ů'},
            { 157, 'Ý'},
            { 128, 'Č'},
            { 133, 'Ď'},
            { 138, 'Ĺ'},
            { 156, 'Ľ'},
            { 165, 'Ň'},
            { 171, 'Ŕ'},
            { 158, 'Ř'},
            { 155, 'Š'},
            { 134, 'Ť'},
            { 146, 'Ž'}
        };
        
        static readonly Dictionary<char, byte> CharMappingDictionary = new Dictionary<char, byte>
        {
            {'ě',136},
            {'ů',150},
            {'ý',152},
            {'č',135},
            {'ď',131},
            {'ĺ',141},
            {'ľ',140},
            {'ň',164},
            {'ŕ',170},
            {'ř',169},
            {'š',168},
            {'ť',159},
            {'ž',145},
            {'Á',143},
            {'Ě',137},
            {'Í',139},
            {'Ó',149},
            {'Ô',167},
            {'Ú',151},
            {'Ů',166},
            {'Ý',157},
            {'Č',128},
            {'Ď',133},
            {'Ĺ',138},
            {'Ľ',156},
            {'Ň',165},
            {'Ŕ',171},
            {'Ř',158},
            {'Š',155},
            {'Ť',134},
            {'Ž',146}
        };
        
        public static bool TryGetChar(byte sourceByte, out char convertedChar)
            => ByteMappingDictionary.TryGetValue(sourceByte, out convertedChar);
        
        public static bool TryGetByte(char sourceChar, out byte convertedByte)
            => CharMappingDictionary.TryGetValue(sourceChar, out convertedByte);
    }
}