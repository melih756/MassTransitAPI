using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitData.DataAccess
{
    public class Data
    {
        public Guid Guid { get; set; }

        public DateTime publishTime = DateTime.Now;
        public int counter { get; set; }
    }
}
