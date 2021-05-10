using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Common.Mongo
{
    public interface IDatabaseInitialize
    {
        Task InitializerAsync();
    }
}
