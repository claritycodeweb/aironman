using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;


namespace AIronMan.Domain {
    public class Layout {
        [Key]
        public int Id { get; set; }

        //public string Title;

        [StringLength(150)]
        public string Name {get; set;}

        public bool IsVisible { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public bool IsSlider { get; set; }
        public bool IsPotfolio { get; set; }
        public bool IsGallery { get; set; }
        public bool IsBlog { get; set; }

        [StringLength(50)]
        public string OnlyForModule { get; set; }
    }
}
