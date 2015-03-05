using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIronMan.Logging
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string message);
        void Error(string message, Exception x);
        void Error(Exception x);
    }
}
