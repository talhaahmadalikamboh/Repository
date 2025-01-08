using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Models;

namespace Repository.Infrastracture
{
    public class ProdectRepository : IProdectRepository
    {
        private readonly MyAppDBContext _context;

        public IEnumerable<object> Prodect1 => throw new NotImplementedException();

        public ProdectRepository(MyAppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prodect1>> GetAll()
        {
            try
            {
                var pordect1 = await _context.Prodect1.ToListAsync();
                return pordect1;
            }
            catch (Exception )
            {
                return Enumerable.Empty<Prodect1>();
            }
        }
        public async Task<Prodect1> GetById(int id)
        {
            return await _context.Prodect1.FindAsync(id);
        }

        public async Task Add(Prodect1 model)
        {
           await _context.Prodect1.AddAsync(model);
           await Save();
        }

        public async Task Update(Prodect1 model)
        {
            var prodect1 = await _context.Prodect1.FindAsync(model.Id);
            if (prodect1 != null)
            {
                prodect1.ProdectName = model.ProdectName;
                prodect1.Price = model.Price;
                prodect1.Qty = model.Qty;
                _context.Update(prodect1);
                await Save();
            }
        }
        public async Task Delete(int id)
        {
            var prodect1 = await _context.Prodect1.FindAsync(id);
            if (prodect1 != null)
            {
                _context.Prodect1.Remove(prodect1);
                await Save();
            }
        }
        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Details(int id)
        {
            await Save();
            //throw new NotImplementedException();
        }
    }
}
