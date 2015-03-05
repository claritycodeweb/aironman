using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class LangRepository :  Repository<Lang> , ILangRepository {
        public LangRepository(DB context) : base(context) { }
    }
}
