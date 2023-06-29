using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchflix.Shared.Events.Interfaces;

namespace Watchflix.Shared.Events
{
    public class LoginCompletedEvent:ILoginCompletedEvent
    {
        public AccessTokenMessage AccessTokenMessage { get; set; }
    }
}
