using System;
using System.Diagnostics;
using System.Security;



namespace WebAppEventLog
{
    class EventLogCounter
    {
        public string LogName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public EventLogCounter (string logName, string startTime, string finishTime)
        {
            LogName = logName;
            try
            {
                StartTime = DateTime.Parse(startTime);
                FinishTime = DateTime.Parse(finishTime);
                if ((StartTime - FinishTime) > TimeSpan.Zero)
                {
                    DateTime time = StartTime;
                    StartTime = FinishTime;
                    FinishTime = time;
                }
            }
            catch
            {
              
            }
        }
        public bool CountEvents(out int error, out int warning, out int info)
        {
            error = 0; warning=0; info = 0;
            try
            {
                if (EventLog.SourceExists(LogName))
                {
                    using (EventLog log = new EventLog(LogName))
                    {

                        for (int i = 0; i < log.Entries.Count; i++)
                        {
                            if (log.Entries[i].TimeWritten.IsInRange(StartTime, FinishTime))
                            {
                                try
                                {
                                    switch (log.Entries[i].EntryType)
                                    {

                                        case EventLogEntryType.Error:
                                            checked { error++; }
                                            break;
                                        case EventLogEntryType.Warning:
                                            checked { warning++; }
                                            break;
                                        case EventLogEntryType.Information:
                                            checked { info++; }
                                            break;

                                    }
                                }
                                catch (OverflowException)
                                {
                                    return false;
                                }
                            }
                        }
                    };
                }
            }
            catch (SecurityException)
            {
                return false;
            }
            return true;
        }

    }
}
