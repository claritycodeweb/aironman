using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIronMan.Domain.Mapping {
    public class LayoutMap {

        public IEnumerable<Layout> Items { get; set; }

        public Layout SelectedLayout { get; set; }

        public int SelectedLayoutId { get; set; }
        public int SelectedSliderId { get; set; }
        public int SelectedPortfolioId { get; set; }
        public int SelectedBlogId { get; set; }

        public IEnumerable<SliderHeader> Sliders { get; set; }
        public IEnumerable<PortfolioHeader> Portfolios { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }

    }
}
