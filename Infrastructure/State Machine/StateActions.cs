namespace State_Machine
{
    public interface IStateActions
    {
        /// <summary>
        /// Выполняется перед входом в состояние
        /// </summary>
        public void OnEnterExecute();
        /// <summary>
        /// Выполняется перед выходом из состояния
        /// </summary>
        public void OnExitExecute();
    }

    public class StateActions<TEnterParameters, TExitParameters>: IStateActions
    {
        private Action<TEnterParameters> OnEnter;
        private Action<TExitParameters> OnExit;
        public TEnterParameters? EnterParameters { get; set; }
        public TExitParameters? ExitParameters { get; set; }

        public StateActions(Action<TEnterParameters> onEnter, Action<TExitParameters> onExit) 
        { 
            this.OnEnter = onEnter;
            this.OnExit = onExit;
        }

        
        public void OnEnterExecute() => OnEnter(EnterParameters);

        public void OnExitExecute() => OnExit(ExitParameters);
    }

    public class EmptyStateAction : IStateActions
    {
        public void OnEnterExecute() { }

        public void OnExitExecute() { }
    }
}