using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AIronMan.Domain {
    public class Tag {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PortfolioNode> PortfolioNodes { get; set; }
    }
}
