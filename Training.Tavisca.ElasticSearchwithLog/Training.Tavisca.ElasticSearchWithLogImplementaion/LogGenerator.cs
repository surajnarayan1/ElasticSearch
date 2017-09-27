using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Training.Tavisca.ElasticSearchWithLogImplementaion
{
   public  class LogGenerator
    {

        Log log;
        public LogGenerator()
        {
            log = new Log();
        }

        private void logRequest(string request)
        {
            log.Request = request;
            Console.WriteLine(log.Request);
        }
        private void logResponse(string response)
        {
            log.Response = response;
            Console.WriteLine(log.Response);
        }
        private void logRequestTime()
        {
            log.requestTime = DateTime.Now.ToString();
            Console.WriteLine(log.requestTime);
        }
        private void logResponseTime()
        {
            log.responseTime = DateTime.Now.ToString();
            Console.WriteLine(log.responseTime);
        }
        private void logStatus(bool value)
        {
            log.isSuccess = value;
            Console.WriteLine(log.isSuccess);
        }
        private void logIpAddress()
        {
            var hostName = Dns.GetHostName();
            log.IpAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Console.WriteLine(log.IpAddress);
        }
        public Log GenerateLog(string request, string response, bool value)
        {
            logRequest(request);
            logResponse(response);
            logStatus(value);
            logRequestTime();
            logIpAddress();
            logResponseTime();

            return log;
        }







    }
}
