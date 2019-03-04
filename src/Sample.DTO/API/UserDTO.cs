using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DTO.API
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
    }
}
