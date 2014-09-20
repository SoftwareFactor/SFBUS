using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    /// <summary>
    /// Main interface of the service bus
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// Starts the service bus
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the service bus
        /// </summary>
        void Stop();

        /// <summary>
        /// Sends a message
        /// </summary>
        void Send(IMessage message);
    }
}
