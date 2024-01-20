namespace State_Machine
{
    public class StateMachine<TEvent, TState> where TState : Enum
    {
        private Dictionary<string, IStateActions> _states = new();
        public string? CurrentState { get; private set; }
        public TransitionGraph<TEvent, string> Transitions = new();
        

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

        public void RegisterAction()
        {

        }

        public string HandleEvent(TEvent trigger)
        {
            _states[CurrentState].OnExit();
            var next = Transitions.GetNextState(trigger, CurrentState);
            CurrentState = next;
            _states[next].OnEnter();
            return next;
        }
    }

    public class IndexedProperty<TState>
    {
        readonly Action<TState, IStateActions> SetAction;
        readonly Func<TState, IStateActions> GetFunc;

        public IndexedProperty(
            Func<TState, IStateActions> getFunc,
            Action<TState, IStateActions> setAction)
        {
            GetFunc = getFunc;
            SetAction = setAction;
        }

        public IStateActions this[TState state]
        {
            get
            {
                return GetFunc(state);
            }
            set
            {
                SetAction(state, value);
            }
        }
    }
}
