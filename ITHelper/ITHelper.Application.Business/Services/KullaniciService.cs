using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using ITHelper.Infranstrucure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Business.Services
{
    public class KullaniciService : IKullaniciService<Kullanici>
    {
        private readonly ITHelperContext _dataContext;

        public KullaniciService(ITHelperContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(Kullanici entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
            return entity.KullaniciID;
        }


        public void Delete(Kullanici entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public Kullanici GetByID(int id)
        {
            return _dataContext.Set<Kullanici>().Find(id);
        }

        public List<Kullanici> GetListAll()
        {
            return _dataContext.Set<Kullanici>().ToList();
        }


        public void Update(Kullanici entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
