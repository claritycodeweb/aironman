using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class SliderStep {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("SliderHeader")]
        public int SliderId { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        //[Required]
        [StringLength(500)]
        public string ImageLocalPath { get; set; }

        //[RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [StringLength(500)]
        public string ImageUrlPath { get; set; }

        [StringLength(500)]
        public string ImageBackground { get; set; }

        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "URL format is wrong")]
        [StringLength(500)]
        public string LinkTo { get; set; }

        [StringLength(125)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public bool IsActive { get; set; }

        //navigation back to parent
        public SliderHeader SliderHeader { get; set; }

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
