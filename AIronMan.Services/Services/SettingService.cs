using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Repository;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using AIronMan.Domain.Mapping;
using System.Configuration;
using System.IO;
using System.Web;
using AIronMan.Utility;

namespace AIronMan.Services
{
    public class SettingService : ServiceBase, ISettingService
    {

        public SettingService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public SettingMap GetAll()
        {
            SettingMap settings = Cache.Get("settings") as SettingMap;
            if (settings == null)
            {
                Guid siteId = SiteId;
                List<Setting> allSettings = Context.SettingRepository.All().Where(m => m.SiteId == siteId).ToList();

                settings = new SettingMap();
                PropertyInfo[] propertiesInfo = settings.GetType().GetProperties();

                foreach (var item in propertiesInfo)
                {

                    SettingStorageAttribute settingAttribute = (SettingStorageAttribute)(typeof(SettingMap).GetProperty(item.Name)
                            .GetCustomAttributes(typeof(SettingStorageAttribute), true).First());

                    List<Setting> model = allSettings.Where(m => m.Name == settingAttribute.Key).ToList();

                    if (model.Count > 0)
                    {
                        item.SetValue(settings, Convert.ChangeType(model.SingleOrDefault().Value, item.PropertyType), null);
                    }
                    else
                    {
                        Setting oneSetting = new Setting
                        {
                            Name = ((SettingStorageAttribute) (typeof (SettingMap).GetProperty(item.Name)
                                .GetCustomAttributes(typeof (SettingStorageAttribute), true).First())).Key,
                            Description = ((DescriptionAttribute) (typeof (SettingMap).GetProperty(item.Name)
                                .GetCustomAttributes(typeof (DescriptionAttribute), true).First())).Description,
                            DisplayName = ((DisplayNameAttribute) (typeof (SettingMap).GetProperty(item.Name)
                                .GetCustomAttributes(typeof (DisplayNameAttribute), true).First())).DisplayName
                        };

                        DefaultValueAttribute[] a = ((DefaultValueAttribute[])(typeof(SettingMap).GetProperty(item.Name)
                            .GetCustomAttributes(typeof(DefaultValueAttribute), true)));

                        oneSetting.Value = a.Length > 0 ? a[0].Value.ToString() : "";

                        item.SetValue(settings, Convert.ChangeType(oneSetting.Value, item.PropertyType), null);
                        oneSetting.SiteId = siteId;
                        allSettings.Add(oneSetting);

                        Context.SettingRepository.Create(oneSetting);
                        Context.Save();
                    }
                }

                Cache.Set("settings", settings, 30);
            }


            return settings;
        }


        public SettingMap Update(SettingMap entity, ref ErrorCode.SettingServiceStatus status)
        {
            if (!String.IsNullOrEmpty(entity.SmtpPassword))
            {
                entity.SmtpPassword = AppUtil.Encrypt(entity.SmtpPassword);
            }

            Guid siteId = SiteId;
            List<Setting> allSettings = Context.SettingRepository.Filter(m => m.SiteId == siteId).ToList();
            SettingMap settings = new SettingMap();
            PropertyInfo[] propertiesInfo = settings.GetType().GetProperties();
            Context.Save();

            foreach (var item in propertiesInfo)
            {
                SettingStorageAttribute settingAttribute = (SettingStorageAttribute)(typeof(SettingMap).GetProperty(item.Name)
                          .GetCustomAttributes(typeof(SettingStorageAttribute), true).First());
                var value = item.GetValue(entity, null);
                allSettings.Where(m => m.Name == settingAttribute.Key).ToList().ForEach(m => m.Value = (value == null ? "" : value.ToString()));
            }

            Context.Save();

            Cache.Invalidate("settings");
            GetAll();

            return entity;
        }


        public String[] GetAllLogoImages()
        {
            SettingMap settings = GetAll();

            String[] logoFiles = Directory.GetFiles(Path.GetFullPath("images/" + settings.Theme + "/logos/"), "*.png", SearchOption.TopDirectoryOnly);

            return logoFiles;
        }
    }
}
