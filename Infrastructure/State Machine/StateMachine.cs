namespace State_Machine
{
    public class StateMachine<TEvent, TState> where TState : Enum where TEvent : ITrigger
    {
        private Dictionary<string, IStateActions> _states = new();
        public string CurrentState { get; private set; }
        private TransitionGraph<TEvent, string> Transitions { get; }

        public StateMachine(TState startState)
        {
            Transitions = new();
            CurrentState = Enum.GetName(typeof(TState), startState);
        }

        public void RegisterStates() 
        {
            var states = Enum.GetValues(typeof(TState));
            foreach (var state in states)
            {
                _states[Enum.GetName(typeof(TState), state)] = new EmptyStateAction();
            }
        }
        public IStateActions this[TState state]
        {
            get
            {
                return _states[Enum.GetName(typeof(TState), state)];
            }
            set
            {
                _states[Enum.GetName(typeof(TState), state)] = value;
            }
        }

        public void RegisterTransition(TState curState, TEvent trigger, TState nextState)
        {
            var curStateName = Enum.GetName(typeof(TState), curState);
            var nextStateName = Enum.GetName(typeof(TState), nextState);
            Transitions.RegisterOrChangeTransition(trigger, curStateName, nextStateName);
        }

        public string HandleEvent(TEvent trigger)
        {
            var curStateName = Enum.GetName(typeof(TState), CurrentState);
            var hasTransition = Transitions.HasTransition(trigger, curStateName);
            var next = Transitions.GetNextState(trigger, CurrentState);
            if (hasTransition)
            {
                trigger.Execute();
            }
            CurrentState = next;
            return next;
        }
    }
}
