namespace Dictionchy.Infrastructure
{
    internal interface IDatabaseProvider<T> //TODO: добавить Update и Delete
    {
        public void Save(T obj, params string[] args);
        public Task<T?> Get(params string[] args);
    }
}
