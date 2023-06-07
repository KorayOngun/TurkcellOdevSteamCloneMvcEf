using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Request
{
    public class NewUserRequest : IDto
    {
        [MaxLength(80,ErrorMessage ="80 karakterden uzun veri girmeyin")]
        [Required(ErrorMessage ="mail gereklidir")]
        public string UserMail { get; set; }
        [Required(ErrorMessage = "kullanıcı adı gereklidir")]
        [MaxLength(80, ErrorMessage = "80 karakterden uzun veri girmeyin")]
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="şifreniz en az 8 karakter olmalı")]
        [MaxLength(80, ErrorMessage = "80 karakterden uzun veri girmeyin")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])).+$",ErrorMessage ="Şifreniz Büyük ve küçük harf içermeli")]
        public string UserPassword { get; set; }
    }
}
