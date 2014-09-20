using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    public interface IHandler<T> where T : IMessage
    {
        /// <summary>
        /// Handle message
        /// </summary>
        /// <param name="message">An IMessage instance to handle</param>
        void Handle(T message);
    }
}