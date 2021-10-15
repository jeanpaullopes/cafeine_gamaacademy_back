using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Repositories
{
    public class ApplicationDBSettings : IApplicatonDBSettings
    {
        public string ConnectionString { get; set; }
    }

    public interface IApplicatonDBSettings
    {
        public string ConnectionString { get; set; }
    }
}
