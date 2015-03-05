using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Common.Pagging;

namespace AIronMan.Domain.Mapping {
    public class PostModelPaggingMap {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public IPagedList<Post> Entries { get; set; }


        public string BloggerName { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets the currently selected tag.
        /// </summary>
        public string Tag { get; set; }

        public Blog Blog { get; set; }
    }
}
