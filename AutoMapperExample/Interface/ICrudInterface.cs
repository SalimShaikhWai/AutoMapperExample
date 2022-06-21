namespace AutoMapperExample.Interface
{
    public interface ICrudInterface<T>
    {
        public  Task CreateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<T> GetByIdAsync(int id);

        public Task Update(T entity);
        public Task<List<T>> GetAllAsync();


    }
}
