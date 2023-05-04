using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DomainModel.DTO.User
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}