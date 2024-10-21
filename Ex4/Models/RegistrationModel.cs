using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ex4.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Tên đơn vị tuyển is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Loại hình doanh nghiệp is required")]
        public string BusinessType { get; set; }

        [Required(ErrorMessage = "Số lượng nhân viên is required")]
        public int EmployeeCount { get; set; }

        [Required(ErrorMessage = "Địa chỉ is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Người liên hệ is required")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Điện thoại is required")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Website { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu is required")]
        [StringLength(100, ErrorMessage = "Mật khẩu must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool ReceiveEmail { get; set; }
    }
}