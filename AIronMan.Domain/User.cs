using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AIronMan.Domain {
    public class User {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [MaxLength(128)]
        public string PasswordSalt { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime LastPasswordChangeDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsLockedOut { get; set;}


        public ICollection<Role> Roles { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }

    }
}
