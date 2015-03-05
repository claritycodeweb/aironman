using System.Linq;

namespace AIronMan.Services
{
    public interface IPageTemplateService
    {
        IQueryable<AIronMan.Domain.PageTemplate> Get();
        AIronMan.Domain.PageTemplate Create(string name, string content, bool isActive, int userId, ref ErrorCode.PageTemplateServiceStatus status);
        AIronMan.Domain.PageTemplate Update(Domain.PageTemplate entity, int userId, ref ErrorCode.PageTemplateServiceStatus status);
        int Delete(int id, ref ErrorCode.PageTemplateServiceStatus status);
        Domain.PageTemplate GetById(int id);
    }
}
