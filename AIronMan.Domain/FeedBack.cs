using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class FeedBack {

        [Required(ErrorMessage = "(The {0} field is required)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "(The {0} field is required)")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "(Invalid Email Adress)")]
        public string Email { get; set; }

        [Required(ErrorMessage="(The {0} field is required)")]
        public string Topic { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "(The {0} field is required)")]
        public string Message { get; set; }

        public bool ReplyTo { get; set; }

    }
}
