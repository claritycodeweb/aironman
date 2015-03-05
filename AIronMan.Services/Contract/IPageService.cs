using AIronMan.Domain;
using System.Collections.Generic;
using System.Linq;
namespace AIronMan.Services
{
    public enum DownUp
    {
        Down = 1,
        Up = 2
    }
    public interface IPageService
    {

        IQueryable<Page> GetAll();
        Page CreatePage(Page entity, ref ErrorCode.PageServiceStatus status);
        int DeletePage(int pageId, ref ErrorCode.PageServiceStatus status);
        void ChangeOrder(int pageId, DownUp downOrUp, ref ErrorCode.PageServiceStatus status);
        Page UpdatePage(Page entity, ref ErrorCode.PageServiceStatus status);
        Page FindPageById(int id);

        IEnumerable<Page> GetAllCachePage();
    }
}
