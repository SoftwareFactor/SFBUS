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
        /// Start providing messages
        /// </summary>
        void Start();

        /// <summary>
        /// Stop providing messages
        /// </summary>
        void Stop();

        /// <summary>
        /// This delegate will be called when new message is retrieved
        /// </summary>
        Action<IMessage> ProvideMessage { get; set; }

        /// <summary>
        /// Send a message to the endpoint
        /// </summary>
        /// <param name="endpoint">Endpoint to send message to</param>
        /// <param name="message">A message to send</param>
        void SendMessage(IEndpoint endpoint, IMessage message);
    }
}
