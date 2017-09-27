using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Tavisca.ElasticSearchWithLogImplementaion
{
    public class Log
    {
        public string Request { get; set; }
        public string Response { get; set; }
        public bool isSuccess { get; set; }
        public string requestTime { get; set; }
        public string responseTime { get; set; }
        public string IpAddress { get; set; }
    }
}
