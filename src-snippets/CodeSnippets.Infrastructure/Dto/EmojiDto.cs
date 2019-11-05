using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Infrastructure.Dto
{
    /// <summary>
    /// Emoji数据传输对象
    /// </summary>
    public class EmojiDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Unicode编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Unicode通用语言环境数据存储库短名字
        /// </summary>
        public string CLDRShortName { get; set; }
    }

    public class FaceSmilingDto
    {
        public List<EmojiDto> FaceSmiling { get; set; }
    }
}
