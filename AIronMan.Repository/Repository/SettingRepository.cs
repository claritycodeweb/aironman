using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class SettingRepository: Repository<Setting> , ISettingRepository{
        public SettingRepository(DB context) : base(context) { }
    }
}
