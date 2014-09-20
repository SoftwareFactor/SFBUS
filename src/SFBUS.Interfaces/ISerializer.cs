using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    public interface ISerializer
    {
        /// <summary>
        /// Serialize message to string
        /// </summary>
        /// <param name="message">Message to serialize</param>
        /// <returns></returns>
        string SerializeMessage(IMessage message);
    }
}
