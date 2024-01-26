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
            Default,
            Actions,
            Conversation,
            Feeding,
            Sleeping,
            Cleaning,
            PetState
        }

        public static StateMachine<ICommand, State> RegisterStateMachine()
        {
            var machine = new StateMachine<ICommand, State>();
            machine.RegisterStates();
            RegisterStatesActions(machine);
            return machine;
        }

        private static void RegisterTransitions(StateMachine<ICommand, State> machine)
        {
            machine.RegisterTransition(
                State.Start,
                new CreatePetCommand(),                  
                State.CreatePet);

            machine.RegisterTransition(
              State.CreatePet,
              new PetCreatedCommand(),
              State.Default);

            machine.RegisterTransition(State.Default,
                new PetActionsCommand(), State.Actions);
            machine.RegisterTransition(State.Default,
                new PetStateCommand(), State.PetState);
           
            machine.RegisterTransition(
                State.Actions,
                new PetCleanCommand(),
                State.Cleaning);
            machine.RegisterTransition(
                State.Actions,
                new PetFeedCommand(),
                State.Feeding);
            machine.RegisterTransition(
                State.Actions,
                new PetSleepCommand(),
                State.Sleeping);
        }

        private static void RegisterStatesActions(StateMachine<ICommand, State> machine)
        {
            //machine[State.CreatePet] = new StateActions();
        }
    }
}
