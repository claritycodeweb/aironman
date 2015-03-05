using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Security;

namespace AIronMan.Services {
    public class FileService : IFileService {
        private readonly string root;

        public FileService(ISettingService settingSrv) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);

            root = settingSrv.GetAll().UploadPath;
            // If it's a virtual path then we can map it, otherwise we'll expect that it's a windows path
            if (root.StartsWith("~")) {
                root = server.MapPath(root);
            }
        }

        public static string ProviderName {
            get { return "Filesystem"; }
        }

        public string MapPath(string path) {
            path = (path ?? string.Empty).Trim();
            while (path.StartsWith("/")) {
                path = path.Substring(1);
            }

            if (path.Contains("..")) throw new SecurityException("The path contained '..', which indicates an attempt to access another directory.");
            if (Regex.IsMatch(path, "^[A-z]:")) throw new SecurityException("An attempt was made to access a different drive");
            var fullPath = Path.GetFullPath(Path.Combine(root, path));
            if (!fullPath.StartsWith(root)) throw new SecurityException("An attempt was made to access an alternative file path");
            return fullPath;
        }

        public string UnmapPath(string fullPath) {
            var path = fullPath.Substring(root.Length);
            path = path.Replace("\\", "/");
            return path;
        }

        public bool IsFile(string path) {
            var fullPath = MapPath(path);
            return System.IO.File.Exists(fullPath);
        }

        public FileItem[] GetItems(string path) {
            var directories = GetDirectories(path);
            var files = GetFiles(path);
            return
                directories.Select(dir => new FileItem {
                    Extension = "",
                    Name = dir.Name,
                    Path = UnmapPath(dir.FullName),
                    FileSize = "",
                    Image = "dir.png",
                    IsDirectory = true,
                    Modified = dir.LastWriteTime.ToString("dd-MMM-yyyy")
                }).Union(files.Select(file => new FileItem {
                    Extension = file.Extension,
                    Name = file.Name,
                    Path = UnmapPath(file.FullName),
                    FileSize = (Math.Round((decimal)file.Length / (decimal)1024, 2)).ToString() + "KB",
                    Image = GetImage(file.Name, file.Extension),
                    Modified = file.LastWriteTime.ToString("dd-MMM-yyyy")
                })).ToArray();
        }

        public String[] GetAllFilesNameFromDirectory(string path, string pattern) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
            String[] files = Directory.GetFiles(Path.GetFullPath(server.MapPath(path)), pattern, SearchOption.TopDirectoryOnly).Select
                                        (path1 => Path.GetFileName(path1))
                                     .ToArray(); ;

            return files;
        }

        public FileInfo[] GetAllFilesInfoFromDirectory(string path, string pattern) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
            var fullPath = Path.GetFullPath(server.MapPath(path));
            return Directory.Exists(fullPath)
                       ? Directory.GetFiles(fullPath, pattern).Select(x => new FileInfo(x)).ToArray()
                       : new FileInfo[0];
        }


        public FileInfo[] GetAllFilesInfoFromDirectory(string path, string pattern, SearchOption options) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
            var fullPath = Path.GetFullPath(server.MapPath(path));
            return Directory.Exists(fullPath)
                       ? Directory.GetFiles(fullPath, pattern, options).Select(x => new FileInfo(x)).ToArray()
                       : new FileInfo[0];
        }

        public String[] GetAllFilesNameFromDirectory(string path, string pattern, SearchOption options) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
            String[] files = Directory.GetFiles(Path.GetFullPath(server.MapPath(path)), pattern, options).Select
                                        (path1 => Path.GetFileName(path1))
                                     .ToArray(); ;

            return files;
        }


        public String[] GetAllDirectoryFromDirectory(string path, string pattern) {
            HttpServerUtilityBase server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
            String[] files = Directory.GetDirectories(Path.GetFullPath(server.MapPath(path)), pattern, SearchOption.TopDirectoryOnly).Select
                                        (path1 => Path.GetFileName(path1))
                                     .ToArray(); ;

            return files;
        }

        public DirectoryInfo[] GetDirectories(string path) {
            var fullPath = MapPath(path);
            return Directory.Exists(fullPath)
                       ? Directory.GetDirectories(fullPath).Select(x => new DirectoryInfo(x)).ToArray()
                       : new DirectoryInfo[0];
        }

        public FileInfo[] GetFiles(string path) {
            var fullPath = MapPath(path);
            return Directory.Exists(fullPath)
                       ? Directory.GetFiles(fullPath).Select(x => new FileInfo(x)).ToArray()
                       : new FileInfo[0];
        }

        public void Move(string oldPath, string newPath) {
            oldPath = MapPath(oldPath);
            newPath = MapPath(newPath);
            if (!System.IO.File.Exists(oldPath)) return;
            Directory.CreateDirectory(Path.GetDirectoryName(newPath));
            System.IO.File.Move(oldPath, newPath);
        }

        public void Delete(string filePath) {
            var fullPath = MapPath(filePath);
            if (IsFile(filePath)) {
                System.IO.File.Delete(fullPath);
            } else {
                Directory.Delete(fullPath, true);
            }
        }

        public void CreateDirectory(string path, string name) {
            var fullPath = MapPath(Path.Combine(path, name));
            Directory.CreateDirectory(fullPath);
        }

        public void Save(Stream inputStream, string path, bool unzip) {
            var fullPath = MapPath(path);

            //if (unzip && IsZipFile(fullPath)) {
            //inputStream.Extract(fullPath);
            //} else {
            SaveStream(inputStream, fullPath);
            //inputStream.Save(fullPath);
            //}
        }


        private void SaveStream(Stream stream, string fileName) {
            var directoryName = Path.GetDirectoryName(fileName);
            Directory.CreateDirectory(directoryName);

            using (var output = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                var size = 2048;
                var data = new byte[size];
                while (size > 0) {
                    size = stream.Read(data, 0, data.Length);
                    if (size > 0) output.Write(data, 0, size);
                }
            }
        }

        //public override ActionResult Render(string path)
        //{
        //    if (IsFile(path))
        //        return new FilePathResult(MapPath(path), mimeHelper.GetMimeType(path));

        //    return new HttpNotFoundResult();
        //}

        protected static string GetImage(string file, string extension) {
            if (string.IsNullOrEmpty(extension) || extension == ".") return "default.png";
            if (extension.StartsWith(".")) extension = extension.Substring(1);
            extension = extension.ToLowerInvariant();
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("/Content/Images/FileTypes/" + extension + ".png"))) {
                return extension + ".png";
            }
            return "default.png";
        }

        protected static bool IsZipFile(string fullPath) {
            var extension = Path.GetExtension(fullPath).ToLowerInvariant();
            return extension == ".zip" || extension == ".gz" || extension == ".tar" || extension == ".rar";
        }
    }
}
