using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class PortfolioHeader {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        private string name;

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name {             
            get { return this.name; }
            set {
                this.name = value;
                this.NameUrl = Regex.Replace(
                value.ToLowerInvariant().Replace(" - ", "-").Replace(" ", "-"),
                "[^\\w^-]",
                string.Empty);
            }}

        [StringLength(32)]
        [Required(ErrorMessage = "*")]
        public string NameUrl { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string LayoutForGroupProject { get; set; }

        [Required]
        [StringLength(150)]
        public string LayoutForSingleProject { get; set; }

        public bool EnableComments { get; set; }

        public ICollection<PortfolioNode> PortfolioNodes { get; set; }

        public User CrUser { get; set; }
        public User LmUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }

        [NotMapped]
        public bool IsAddPage { get; set; }

    }
}
