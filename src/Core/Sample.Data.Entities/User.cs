using System;

namespace Sample.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Remark { get; set; }
    }
}
