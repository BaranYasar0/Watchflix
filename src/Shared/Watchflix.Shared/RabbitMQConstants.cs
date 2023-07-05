using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchflix.Shared
{
    public static class RabbitMQConstants
    {
        public const string LoginCompletedQueueName = "login-completed-queue-name";
        public const string PhotoStockedQueueName = "photo-stocked-queue-name";
    }
}
