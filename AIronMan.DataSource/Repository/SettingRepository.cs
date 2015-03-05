using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class SettingRepository: Repository<Setting> , ISettingRepository{
        public SettingRepository(DB context) : base(context) { }
    }
}
