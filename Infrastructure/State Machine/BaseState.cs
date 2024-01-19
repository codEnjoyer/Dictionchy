namespace State_Machine
{
    public abstract class BaseState
    {
        /// <summary>
        /// Выполняется перед входом в состояние
        /// </summary>
        public void OnEnter() { } 
        /// <summary>
        /// Выполняется перед выходом из состояния
        /// </summary>
        public void OnExit() { } 
    }
}