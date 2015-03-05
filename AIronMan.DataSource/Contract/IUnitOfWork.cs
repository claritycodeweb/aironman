using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIronMan.DataSource {
    public interface IUnitOfWork {
        void Save();
    }
}
