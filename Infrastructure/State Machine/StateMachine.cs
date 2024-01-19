namespace State_Machine
{
    public class StateMachine<TEvent>
    {
        public BaseState CurrentState { get; private set; }
        public TransitionGraph<TEvent> Transitions = new TransitionGraph<TEvent>();

        public StateMachine(BaseState startState) 
        {
            CurrentState = startState;
        }

        public BaseState HandleEvent(TEvent trigger)
        {
            CurrentState.OnExit();
            var next = Transitions.GetNextState(trigger, CurrentState);
            CurrentState = next;
            next.OnEnter();
            return next;
        }
    }
}
