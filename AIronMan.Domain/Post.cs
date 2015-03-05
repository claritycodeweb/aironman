using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class Post {
        public int Id { get; set; }

        public bool IsVisible { get; set; }

        private string title;

        [StringLength(150)]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Title {
            get { return this.title; }
            set {
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

        [AllowHtml]
        [StringLength(1500)]
        public string ShortContent { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [StringLength(500)]
        public string DownloadFilePath { get; set; }

        [NotMapped]
        public string DownloadFile {
            get {
                if (!String.IsNullOrEmpty(DownloadFilePath)) {
                    int lastIndex = DownloadFilePath.LastIndexOf('/');
                    return DownloadFilePath.Substring(lastIndex, DownloadFilePath.Length - lastIndex).Replace("/", "");
                } else {
                    return "";
                }
            }
        }

        public bool EnableComments { get; set; }

        [Required]
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public User CrUser { get; set; }
        public User LmUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }


        [NotMapped]
        public string Url {
            get {
                string bloggerName = this.Blog.BloggerName.ToLower().Replace(" ", "-");
                return bloggerName + "/" + this.CrDate.Year + "/" + this.CrDate.Month + "/" + this.CrDate.Day + "/" + this.TitleUrl;
            }
        }

        public string GetTagName(int index) {
            if (this != null && this.Tags != null && this.Tags.Count > index) {
                return this.Tags.ElementAt(index).Name;
            } else {
                return null;
            }
        }

        public string MetaTitle { get; set; }

        public bool DisableComments { get; set; }
    }
}
