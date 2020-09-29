using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcelDemo
{
    /// <summary>
    ///     学生状态 正常、流失、休学、勤工俭学、顶岗实习、毕业、参军
    /// </summary>
    public enum StudentStatus
    {
        /// <summary>
        ///     正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 0,

        /// <summary>
        ///     流失
        /// </summary>
        [Description("流水")]
        PupilsAway = 1,

        /// <summary>
        ///     休学
        /// </summary>
        [Display(Name = "休学")]
        Suspension = 2,

        /// <summary>
        ///     勤工俭学
        /// </summary>
        [Display(Name = "勤工俭学")]
        WorkStudy = 3,

        /// <summary>
        ///     顶岗实习
        /// </summary>
        [Display(Name = "顶岗实习")]
        PostPractice = 4,

        /// <summary>
        ///     毕业
        /// </summary>
        [Display(Name = "毕业")]
        Graduation = 5,

        /// <summary>
        ///     参军
        /// </summary>
        [Display(Name = "参军")]
        JoinTheArmy = 6
    }
}
