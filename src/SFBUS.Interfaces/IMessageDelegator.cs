using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    public interface IMessageDelegator
    {
        IEndpoint DetermineEndpointForMessage(IMessage message);
    }
}
