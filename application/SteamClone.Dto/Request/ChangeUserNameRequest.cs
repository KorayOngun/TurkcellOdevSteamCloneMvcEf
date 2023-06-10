using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Request
{
    public class ChangeUserNameRequest : IDto
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public string NewUserName { get; set; }
    }
}
