using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchflix.Shared.Pipelines
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}
