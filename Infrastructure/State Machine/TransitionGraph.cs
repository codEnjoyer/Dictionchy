namespace State_Machine
{
    public class TransitionGraph<TEvent, TState>
    {
        private Dictionary<ValueTuple<TState, TEvent>, TState> _transitions = new ();

        public void RemoveTransition(TEvent trigger, TState curState)
        {
            _transitions.Remove(new ValueTuple<TState, TEvent>(curState, trigger));
        }

        public void RegisterOrChangeTransition(TEvent trigger, TState curState, TState nextState)
        {
            _transitions[new ValueTuple<TState, TEvent>(curState, trigger)] = nextState;
        }

        public TState GetNextState(TEvent trigger, TState curState) 
        {
            var transition = new ValueTuple<TState  , TEvent>(curState, trigger);
            if (_transitions.ContainsKey(transition))
                return _transitions[transition];
            return curState;
        }

        public bool HasTransition(TEvent trigger, TState curState)
        {
            return _transitions.ContainsKey(new ValueTuple<TState, TEvent>(curState, trigger));
        }
    }
}
