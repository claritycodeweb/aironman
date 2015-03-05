using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class Blog {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        [Required]
        [StringLength(60)]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        [Required]
        [StringLength(32)]
        public string BloggerName { get; set; }

        [Required]
        [StringLength(150)]
        public string LayoutForGroupPost { get; set; }

        [Required]
        [StringLength(150)]
        public string LayoutForSinglePost{ get; set; }


        public bool IsActive { get; set; }
        public ICollection<Post> Posts { get; set; }

        public User CrUser { get; set; }
        public User LmUser { get; set; }



        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }
    }
}
