using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AIronMan.Domain {
    public class Site {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        //[RegularExpression(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")]
        [StringLength(150)]
        [Required]
        public String Url { get; set; }

        [StringLength(150)]
        [Required]
        public String FolderPath { get; set; }

        [StringLength(150)]
        public String ThemeLocalization { get; set; }

        public bool IsActive { get; set; }

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
