using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class LangRepository :  Repository<Lang> , ILangRepository {
        public LangRepository(DB context) : base(context) { }
    }
}
