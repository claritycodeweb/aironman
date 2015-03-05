using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace AIronMan.Domain
{
    public class PortfolioNode
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PortfolioHeader")]
        public int PortfolioId { get; set; }

        private string title;

        [StringLength(150)]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.TitleUrl = Regex.Replace(
                value.ToLowerInvariant().Replace(" - ", "-").Replace(" ", "-"),
                "[^\\w^-]",
                string.Empty);
            }
        }

        [StringLength(160)]
        [Required(ErrorMessage = "*")]
        public string TitleUrl { get; set; }

        [StringLength(500)]
        public string ImageProjectThumbLocalPath { get; set; }

        //[Required]
        [StringLength(500)]
        public string ImageProjectThumbUrlPath { get; set; }

        [StringLength(500)]
        public string ImageProjectLocalPath { get; set; }

        //[Required]
        [StringLength(500)]
        public string ImageProjectUrlPath { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(500)]
        public string ProjectUrlPath { get; set; }

        [AllowHtml]
        [StringLength(500)]
        public string ShortContent { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public bool IsVisible { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        //navigation back to parent
        public virtual PortfolioHeader PortfolioHeader { get; set; }

        [NotMapped]
        public string Url
        {
            get
            {
                string portfolioName = this.PortfolioHeader.NameUrl;
                return portfolioName + "/" + this.CrDate.Year + "/" + this.CrDate.Month + "/" + this.CrDate.Day + "/" + this.TitleUrl;
            }
        }

        public string GetCategoryName(int index)
        {
            if (this != null && this.Tags != null && this.Tags.Count > index)
            {
                return this.Tags.ElementAt(index).Name;
            }
            else
            {
                return null;
            }
        }

        public virtual User CrUser { get; set; }
        public User LmUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }

        [StringLength(500)]
        public string DownloadFilePath { get; set; }

        [NotMapped]
        public string DownloadFile
        {
            get
            {
                if (!String.IsNullOrEmpty(DownloadFilePath))
                {
                    int lastIndex = DownloadFilePath.LastIndexOf('/');
                    return DownloadFilePath.Substring(lastIndex, DownloadFilePath.Length - lastIndex).Replace("/", "");
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
