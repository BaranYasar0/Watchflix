using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchflix.Shared.Events.Interfaces;

namespace Watchflix.Shared.Events
{
    public class PhotoStockedEvent : IPhotoStockedEvent
    {
        public string PhotoUrl { get; set; }
        public Guid MediaId { get; set; }
    }
}
