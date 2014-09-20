using SFBUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS
{
    public class Bus : IBus
    {
        private readonly ITransport _transport;
        private readonly IHandlerLocator _handlerLocator;
        private readonly IEndpointLocator _endpointLocator;
        private readonly ILogger _logger;

        public Bus(ITransport transport, IHandlerLocator handlerLocator, IEndpointLocator endpointLocator, ILogger logger)
        {
            _transport = transport;
            _handlerLocator = handlerLocator;
            _endpointLocator = endpointLocator;
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInfo("Starting bus");
            _transport.ProvideMessage = Process;
            _transport.Start();
        }

        public void Stop()
        {
            _logger.LogInfo("Stopping bus");
            _transport.Stop();
        }

        public void Send(IMessage message)
        {
            var endpoint = _endpointLocator.LocateEndpointForMessage(message);
            _transport.SendMessage(endpoint, message);
        }

        public void Process(IMessage message)
        {
            var handler = _handlerLocator.LocateHandlerForMessage(message);
            handler.Handle(message);
        }
    }
}
