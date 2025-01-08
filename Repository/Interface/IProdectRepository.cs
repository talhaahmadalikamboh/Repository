using Repository.Models;

namespace Repository.Interface
{
    public interface IProdectRepository
    {
        IEnumerable<object> Prodect1 { get; }

        Task<IEnumerable<Prodect1>> GetAll();
        Task<Prodect1> GetById(int id);
        Task Add(Prodect1 model);
        Task Update(Prodect1 model);
        Task Delete(int id);
        Task Details(int id);
    }
}
