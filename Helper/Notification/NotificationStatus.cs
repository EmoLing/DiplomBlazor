using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Notification
{
    public static class NotificationStatus
    {
        public enum Status
        {
            Primary,
            Success,
            Warning,
            Danger
        }

        public static string GetStatus(Status status) => status switch
        {
            Status.Primary => "primary",
            Status.Success => "success",
            Status.Warning => "warning",
            Status.Danger => "danger",
            _ => String.Empty
        };
    }
}
