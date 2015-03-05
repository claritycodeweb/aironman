using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Common.Pagging;

namespace AIronMan.Domain.Mapping {
    public class PortfolioModelPaggingMap {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public IPagedList<PortfolioNode> Entries { get; set; }

        public PortfolioHeader Header { get; set; }

        public string PortfolioName { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets the currently selected tag.
        /// </summary>
        public string Category { get; set; }

    }
}
