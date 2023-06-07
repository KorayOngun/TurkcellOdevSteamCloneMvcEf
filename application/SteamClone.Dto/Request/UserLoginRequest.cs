using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Request
{
    public class UserLoginRequest : IDto
    {
        [Required(ErrorMessage ="kullanıcı adı boş olamaz")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
