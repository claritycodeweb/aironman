using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class File {

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(4)]
        [Required]
        public string Extension { get; set; }

        public int Counter { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [NotMapped]
        public byte[] Data {
            get {
                return System.IO.File.ReadAllBytes(this.FullPath);
            }

            set {
                System.IO.File.WriteAllBytes(this.FullPath, value);
            }
        }

        private string RelativePath {
            get {
                return ConfigurationManager.AppSettings["BlogEntryFilePath"] + this.Id.ToString() + "." + this.Extension;
            }
        }

        private string FullPath {
            get {
                var applicationPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
                return Path.Combine(applicationPath, this.RelativePath);
            }
        }

        /// <summary>
        /// Deletes the corresponding file.
        /// </summary>
        internal void DeleteData() {
            System.IO.File.Delete(this.FullPath);
        }

    }
}
