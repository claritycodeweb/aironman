using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services {
    public class LangService :ServiceBase, ILangService {
        public LangService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public IEnumerable<Domain.Lang> GetAll() {
            var langs = Cache.Get("demoefcf_langs") as IEnumerable<Domain.Lang>;

            if (langs == null) {

                langs = Context.LangRepository.All().ToList();

                if (langs.Any()) {
                    // Put this data into the cache for 30 minutes
                    Cache.Set("demoefcf_langs", langs, 60);
                }
            }

            return langs;
        }
    }
}
