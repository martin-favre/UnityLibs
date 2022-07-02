using Moq;
using NUnit.Framework;
namespace StateMachine
{


    public class UpdatelessStateMachineTest
    {

        Mock<UpdatelessState> stateMock;
        StateMachine stateMachine;
        Mock<UpdatelessState> nextStateMock;

        [SetUp]
        public void setup()
        {
            nextStateMock = new Mock<UpdatelessState>();
            stateMock = new Mock<UpdatelessState>();
        }

        [Test]
        public void ShouldCallOnEntryOnCreation()
        {
            stateMachine = new StateMachine(stateMock.Object);
            stateMock.Verify(stateMock => stateMock.OnEntry(), Times.Once());
            stateMock.Verify(stateMock => stateMock.OnExit(), Times.Never());
        }


        [Test]
        public void NoActionOnNoTransition()
        {
            stateMock.Setup(stateMock => stateMock.HandleEvent(It.IsAny<Tick>())).Returns(StateMachine.NoTransition());
            stateMachine = new StateMachine(stateMock.Object);
            stateMachine.RaiseEvent(new Tick());
            stateMock.Verify(stateMock => stateMock.OnEntry(), Times.Once()); // once on creation
            stateMock.Verify(stateMock => stateMock.OnExit(), Times.Never());
        }

        [Test]
        public void ShouldCallOnExitAndOnEntryOnStateTransition()
        {

            stateMock.Setup(stateMock => stateMock.HandleEvent(It.IsAny<Tick>())).Returns(nextStateMock.Object);
            stateMachine = new StateMachine(stateMock.Object);
            stateMachine.RaiseEvent(new Tick());
            stateMock.Verify(stateMock => stateMock.OnEntry(), Times.Once()); // once on creation
            stateMock.Verify(stateMock => stateMock.OnExit(), Times.Once());
            nextStateMock.Verify(nextStateMock => nextStateMock.OnEntry(), Times.Once());
            nextStateMock.Verify(nextStateMock => nextStateMock.OnExit(), Times.Never());
        }

        [Test]
        public void ShouldExitAndTerminateOnMachineExit()
        {

            stateMock.Setup(stateMock => stateMock.HandleEvent(It.IsAny<Tick>())).Returns(StateMachine.MachineTerminated());
            stateMachine = new StateMachine(stateMock.Object);

            Assert.True(stateMachine.IsActive); // reality check

            stateMachine.RaiseEvent(new Tick());
            stateMock.Verify(stateMock => stateMock.OnEntry(), Times.Once()); // once on creation
            stateMock.Verify(stateMock => stateMock.OnExit(), Times.Once());
            Assert.False(stateMachine.IsActive);
        }
    }

}