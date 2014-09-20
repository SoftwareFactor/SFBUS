using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    public interface ITransport
    {
        /// <summary>
        /// Retrieve next message from the endpoint
        /// </summary>
        /// <param name="endpoint">Endpoint to retrieve message from</param>
        /// <returns></returns>
        IMessage GetNextMessage(IEndpoint endpoint);

        /// <summary>
        /// Send a message to the endpoint
        /// </summary>
        /// <param name="endpoint">Endpoint to send message to</param>
        /// <param name="message">A message to send</param>
        void SendMessage(IEndpoint endpoint, IMessage message);
    }
}
