using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFBUS.Interfaces;
using Moq;

namespace SFBUS.Tests
{
    [TestClass]
    public class BusTest
    {
        private Mock<ITransport> _moqTransport = new Mock<ITransport>();
        private Mock<IHandlerLocator> _moqHandlerLocator = new Mock<IHandlerLocator>();
        private Mock<IEndpointLocator> _moqEndpointLocator = new Mock<IEndpointLocator>();
        private Mock<ILogger> _moqLogger = new Mock<ILogger>();
        private Mock<IMessage> _moqMessage = new Mock<IMessage>();
        private Mock<IEndpoint> _moqEndpoint = new Mock<IEndpoint>();
        private Mock<IHandler<IMessage>> _moqHandler = new Mock<IHandler<IMessage>>();
        private Bus _bus;

        [TestInitialize]
        public void Initializer()
        {
            _bus = new Bus(_moqTransport.Object, _moqHandlerLocator.Object, _moqEndpointLocator.Object, _moqLogger.Object); 
        }

        [TestMethod]
        public void Bus_Start_ShouldSubscribeToMessages()
        {
            //ARRANGE
            Action<IMessage> actionToTest = _bus.Process; 
            //ACT
            _bus.Start();
            //ASSERT
            _moqTransport.VerifySet(x => x.ProvideMessage = It.Is<Action<IMessage>>(a => a.Equals(actionToTest)), Times.Once());
        }

        [TestMethod]
        public void Bus_Start_ShouldStartTransport()
        {
            //ACT
            _bus.Start();
            //ASSERT
            _moqTransport.Verify(t => t.Start());
        }

        [TestMethod]
        public void Bus_Start_ShouldLogStatus()
        {
            //ACT
            _bus.Start();
            //ASSERT
            _moqLogger.Verify(l => l.LogInfo(It.IsAny<string>()));
        }
        
        [TestMethod]
        public void Bus_Stop_ShouldStopTransport()
        {
            //ACT
            _bus.Stop();
            //ASSERT
            _moqTransport.Verify(t => t.Stop());
        }

        [TestMethod]
        public void Bus_Stop_ShouldLogStatus()
        {
            //ACT
            _bus.Stop();
            //ASSERT
            _moqLogger.Verify(l => l.LogInfo(It.IsAny<string>()));
        }

        [TestMethod]
        public void Bus_Send_LocateEndpointAndSendMessageToIt()
        {
            //ARRANGE
            _moqEndpointLocator.Setup(e => e.LocateEndpointForMessage(It.Is<IMessage>(m => m == _moqMessage.Object))).Returns(_moqEndpoint.Object);
            //ACT
            _bus.Send(_moqMessage.Object);
            //ASSERT
            _moqTransport.Verify(t => t.SendMessage(It.Is<IEndpoint>(e => e == _moqEndpoint.Object), It.Is<IMessage>(m => m == _moqMessage.Object)), Times.Once());
        }

        [TestMethod]
        public void Bus_Process_LocateHandlerAndExecute()
        {
            //ARRANGE
            _moqHandlerLocator.Setup(e => e.LocateHandlerForMessage(It.Is<IMessage>(m => m == _moqMessage.Object))).Returns(_moqHandler.Object);
            //ACT
            _bus.Process(_moqMessage.Object);
            //ASSERT
            _moqHandler.Verify(t => t.Handle(It.Is<IMessage>(e => e == _moqMessage.Object)), Times.Once());
        }
    }
}
