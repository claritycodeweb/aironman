using AIronMan.Domain;
using System;
using System.IO;

namespace AIronMan.Services
{
    public interface IFileService
    {
        bool IsFile(string path);
        FileItem[] GetItems(string path);

        void Move(string oldPath, string newPath);
        void Delete(string filePath);
        string MapPath(string path);

        void CreateDirectory(string path, string name);
        void Save(Stream inputStream, string path, bool unzip);

        String[] GetAllFilesNameFromDirectory(string path, string pattern);
        String[] GetAllFilesNameFromDirectory(string path, string pattern, SearchOption options);

        String[] GetAllDirectoryFromDirectory(string path, string pattern);

        FileInfo[] GetAllFilesInfoFromDirectory(string path, string pattern);
        FileInfo[] GetAllFilesInfoFromDirectory(string path, string pattern, SearchOption options);
        //ActionResult Render(string path);
    }
}
