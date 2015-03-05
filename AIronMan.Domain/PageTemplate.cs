using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class PageTemplate {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public Site Site { get; set; }
             
        public int TemplateId { get; set; }
        public String Lang { get; set; }

        [MaxLength(32)]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Required]
        public string Name { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        public bool IsActive { get; set; }

        public User CrUser { get; set; }
        public User LmUser { get; set; }

        //public ICollection<Page> Pages { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }
    }
}
