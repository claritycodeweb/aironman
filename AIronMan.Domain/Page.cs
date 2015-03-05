using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class Page {

        public int Id { get; set; }

        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public Site Site { get; set; }

        [ForeignKey("PageParent")]
        public int? PageParentId { get; set; }
        public Page PageParent { get; set; }

        private string name;
        [Required]
        public string Name {
            get {
                return name;
            }
            set { name = value; }
        }

        [Required]
        public string Url { get; set; }

        public string PageTitle { get; set; }

        [StringLength(150)]
        public string PageLayout { get; set; }

        public string MenuTitle { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string Authorized { get; set; }

        public bool MainMenu { get; set; }

        public int SortOrder { get; set; }

        public bool Active { get; set; }

        public bool DisplayPageTitle { get; set; }

        public string Link { get; set; }

        public bool UnderConstruction { get; set; }

        //[ForeignKey("PageTemplateContent")]
        public int? PageTempleteContentId { get; set; }
        [NotMapped]
        public PageTemplate PageTemplateContent { get; set; }

        [ForeignKey("SliderHeader")]
        public int? SliderHeaderId { get; set; }
        public SliderHeader SliderHeader { get; set; }

        //[ForeignKey("PortfolioHeader")]
        public int? PortfolioHeaderId { get; set; }
        //[NotMapped]
        public PortfolioHeader PortfolioHeader { get; set; }

        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }

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
