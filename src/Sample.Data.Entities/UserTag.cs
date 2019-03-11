using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data.Entities
{
    [Table("UsersTags")]
    public class UserTag
    {
        /// <summary>
        /// 自增主键使用[Key]，非自增主键使用 [ExplicitKey](比如uuid)
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
