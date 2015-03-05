using System.Collections.Generic;

namespace AIronMan.Services
{
    public interface ILangService
    {
        IEnumerable<Domain.Lang> GetAll();
    }
}
