using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using ITHelper.Infranstrucure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Business.Services
{
    public class EtiketService : IEtiketService<Etiket>
    {
        private readonly ITHelperContext _dataContext;

        public EtiketService(ITHelperContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(Etiket entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
            return entity.EtiketID;

        }

        public void Delete(Etiket entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }


        public Etiket GetByID(int id)
        {
            return _dataContext.Set<Etiket>()
                .Include(b => b.BlogEtiketler)
                .ThenInclude(a => a.Etiket)
                .FirstOrDefault(b => b.EtiketID == id);
        }

        public List<Etiket> GetListAll()
        {
            return _dataContext.Set<Etiket>().ToList();
        }

        public void Update(Etiket entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
