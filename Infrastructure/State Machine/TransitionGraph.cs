namespace State_Machine
{
    public class TransitionGraph<TEvent>
    {
        private Dictionary<ValueTuple<BaseState, TEvent>, BaseState> _transitions = new ();

        public void RemoveTransition(TEvent trigger, BaseState curState)
        {
            _transitions.Remove(new ValueTuple<BaseState, TEvent>(curState, trigger));
        }

        public void RegisterOrChangeTransition(TEvent trigger, BaseState curState, BaseState nextState)
        {
            _transitions[new ValueTuple<BaseState, TEvent>(curState, trigger)] = nextState;
        }

        public BaseState GetNextState(TEvent trigger, BaseState curState) 
        {
            var transition = new ValueTuple<BaseState, TEvent>(curState, trigger);
            if (_transitions.ContainsKey(transition))
                return _transitions[transition];
            return curState;
        }

        public bool HasTransition(TEvent trigger, BaseState curState)
        {
            return _transitions.ContainsKey(new ValueTuple<BaseState, TEvent>(curState, trigger));
        }
    }
}
