using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Interfaces
{
    public interface ILocalNotificationsService
    {
        void ShowNotification(string title, string message, IDictionary<string, string> data);
    }
}
