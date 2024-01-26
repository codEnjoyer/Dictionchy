using Dictionchy.Application.Commands;
using State_Machine;

namespace Dictionchy.Application
{
    public static class StatesRegister
    {
        public enum State
        {
            Start,
            CreatePet,
            Dafault,
            Conversation,
            Feeding,
            Sleeping,
            Cleaning
        }

        public static StateMachine<ICommand, State> RegisterStateMachine()
        {
            var machine = new StateMachine<ICommand, State>();
            machine.RegisterStates();
            RegisterStatesActions(machine);
            return machine;
        }

        private static void RegisterTransitions()
        {

        }

        private static void RegisterStatesActions(StateMachine<ICommand, State> machine)
        {
            //machine[State.CreatePet] = new StateActions();
        }
    }
}
