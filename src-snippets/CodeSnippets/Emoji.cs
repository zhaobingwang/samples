using System;
using System.Text;

namespace CodeSnippets
{
    public class Emoji
    {
        /// <summary>
        /// 字符串形式的 Emoji 16进制Unicode编码  转换成 UTF16字符串 能够直接输出到客户端
        /// </summary>
        /// <param name="emojiCode"></param>
        /// <returns></returns>
        public static string EmojiCodeToUTF16String(string emojiCode)
        {
            if (emojiCode.Length != 4 && emojiCode.Length != 5)
            {
                throw new ArgumentException("错误的 EmojiCode 16进制数据长度.一般为4位或5位");
            }
            // 1f604
            int emojiUnicodeHex = int.Parse(emojiCode, System.Globalization.NumberStyles.HexNumber);

            // 1f604对应 utf16 编码的int
            int emojiUTF16Hex = EmojiToUTF16(emojiUnicodeHex, true);  // 这里字符的低位在前.高位在后.
            var emojiBytes = BitConverter.GetBytes(emojiUTF16Hex);  // 把整型值变成Byte[]形式. Int64的话 丢掉高位的空白0000000   

            return Encoding.Unicode.GetString(emojiBytes);
        }

        private static Int32 EmojiToUTF16(int v, bool lowHeight = true)
        {

            int vx = v - 0x10000;

            int vh = vx >> 10;    // 取高10位部分
            int vl = vx & 0x3ff;  // 取低10位部分

            int wh = 0xD800;  // 结果的前16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            int wl = 0xDC00;  // 结果的后16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            wh = wh | vh;
            wl = wl | vl;
            if (lowHeight)
            {
                return wl << 16 | wh;   // 低位左移16位以后再把高位合并起来 得到的结果是UTF16的编码值   // 适合低位在前的操作系统 
            }
            else
            {
                return wh << 16 | wl;   // 高位左移16位以后再把低位合并起来 得到的结果是UTF16的编码值   // 适合高位在前的操作系统
            }
        }
    }
}
