namespace State_Machine
{
    public interface IStateActions
    {
        /// <summary>
        /// Выполняется перед входом в состояние
        /// </summary>
        public void OnEnter();
        /// <summary>
        /// Выполняется перед выходом из состояния
        /// </summary>
        public void OnExit();
    }

    public class StateActions<TEnterParameters, TExitParameters>: IStateActions
    {
        private readonly Action<TEnterParameters> onEnter;
        private readonly Action<TExitParameters> onExit;
        public TEnterParameters? EnterParameters { get; set; }
        public TExitParameters? ExitParameters { get; set; }

        public StateActions(Action<TEnterParameters> onEnter, Action<TExitParameters> onExit) 
        { 
            this.onEnter = onEnter;
            this.onExit = onExit;
        }

        
        public void OnEnter() => onEnter(EnterParameters);

        public void OnExit() => onExit(ExitParameters);
    }

    public class EmptyStateAction : IStateActions
    {
        public void OnEnter() { }

        public void OnExit() { }
    }
}