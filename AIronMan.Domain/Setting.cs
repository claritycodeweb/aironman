using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIronMan.Domain
{
    public class Setting
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(400)]
        public string DisplayName { get; set; }

        [StringLength(int.MaxValue)]
        public string Value { get; set; }
    }
}
