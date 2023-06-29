using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchflix.Shared.Events
{
    public class AccessTokenMessage
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
