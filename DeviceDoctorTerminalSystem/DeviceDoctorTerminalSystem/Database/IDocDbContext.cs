namespace DeviceDoctorTerminalSystem.Database
{
    public interface IDocDbContext
    {
        public IEnumerable<T> All<T>() where T : class;

        public T? Get<T>(Func<T, bool> condition) where T : class;

        public void Remove<T>(T entity) where T : class;

        public void Add<T>(T entity) where T : class;

        public Task UpdateDatabase(Action performAction);
    }
}
