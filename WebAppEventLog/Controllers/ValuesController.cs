using System.Collections.Generic;
using System.Web.Http;

namespace WebAppEventLog.Controllers
{
    public class ValuesController : ApiController
    {
        //GET 
        public IEnumerable<string> Get(string logName, string startTime, string finishTime)
        {
            var eventLog = new EventLogCounter(logName, startTime, finishTime);
            int Err, Warr, Info;
            var success = eventLog.CountEvents(out Err, out Warr, out Info);
            if (success)
                return new string[] { Err.ToString(), Warr.ToString(), Info.ToString() };
            else
                return new string[] { "-1", "-1", "-1" };

        }

    }
}
