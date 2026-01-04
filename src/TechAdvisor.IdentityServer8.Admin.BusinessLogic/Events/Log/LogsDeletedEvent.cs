using System;
using TechAdvisor.AuditLogging.Events;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Events.Log
{
    public class LogsDeletedEvent : AuditEvent
    {
        public DateTime DeleteOlderThan { get; set; }

        public LogsDeletedEvent(DateTime deleteOlderThan)
        {
            DeleteOlderThan = deleteOlderThan;
        }
    }
}