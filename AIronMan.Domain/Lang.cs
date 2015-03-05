using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIronMan.Domain {
    public class Lang {
        [Key]
        public int Id { get; set; }
        public string LangCode { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public bool IsCurrentActive { get; set; }
    }
}
