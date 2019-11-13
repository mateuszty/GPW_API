using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.Core.ExternalResources
{
    public interface IDataRefresh
    {
        public event EventHandler DataRefreshing;

        void Refresh();

    }
}
