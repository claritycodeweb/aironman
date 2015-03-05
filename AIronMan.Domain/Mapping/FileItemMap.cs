using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIronMan.Domain.Mapping {
    public class FileItemMap {
        public FileItemMap(string path, FileItem[] items) {
            Items = items;
            PathString = path;

            var parts = new List<PathPart>();
            parts.Add(new PathPart("Home", "/"));
            var pathBuilder = "";
            foreach (var part in path.Split('/')) {
                if (part.Length == 0) continue;
                pathBuilder += "/" + part;
                parts.Add(new PathPart(part, pathBuilder));
            }
            Path = parts.ToArray();
        }

        public string PathString { get; set; }
        public PathPart[] Path { get; set; }
        public FileItem[] Items { get; set; }

        public FileItem SelectFileItem { get; set; }

        public class PathPart {
            public PathPart(string name, string path) {
                Name = name;
                Path = path;
            }

            public string Name { get; set; }
            public string Path { get; set; }
        }
    }
}
