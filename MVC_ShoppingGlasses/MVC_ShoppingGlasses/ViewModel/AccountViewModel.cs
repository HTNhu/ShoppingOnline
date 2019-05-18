using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ShoppingGlasses.ViewModel
{
    public class AccountViewModel
    {
        
    }
    public class RegisterViewModel
    {
    
        [Required(ErrorMessage = "*Tên tài khoản bắt buộc nhập")]
        [DisplayName("Tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*Mật khẩu bắt buộc nhập")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*Xác nhận bắt buộc")]
        [Compare("Password",ErrorMessage ="Mật khẩu không trùng khớp")]
        [DataType(DataType.Password)]
        [DisplayName("Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        [Required]
        [RegularExpression("[0-9]{10}",ErrorMessage ="Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*User Name bắt buộc")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*Password bắt buộc")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }


}
