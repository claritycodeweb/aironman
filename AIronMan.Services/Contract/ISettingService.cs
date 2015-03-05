using AIronMan.Domain.Mapping;
using System;

namespace AIronMan.Services
{
    public interface ISettingService
    {
        SettingMap GetAll();

        SettingMap Update(SettingMap entity, ref ErrorCode.SettingServiceStatus status);

        String[] GetAllLogoImages();
    }
}
