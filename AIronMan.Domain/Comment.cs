using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class Comment {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",ErrorMessage="Invalid Email Adress")]
        [StringLength(50)]
        public string Email { get; set; }

        //[RegularExpression(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")]
        [StringLength(100)]
        public string HomePage { get; set; }

        public bool IsAdmin { get; set; }

        public bool Visible { get; set; }

        public bool IsBlock { get; set; }

        [Required]
        public string Content { get; set; }

        // jeśli uzupełnione postid to komentarz do posta
        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

        // jeśli uzupełnine portfolionodeid to komentarz do projektu z portofoli
        [ForeignKey("PortfolioNode")]
        public int? PortfolioNodeId { get; set; }
        public PortfolioNode PortfolioNode { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }
    }
}
