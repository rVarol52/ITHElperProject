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
    public class BlogEtiketService : IBlogEtiketService<BlogEtiket>
    {

        private readonly ITHelperContext _dataContext;

        public BlogEtiketService(ITHelperContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(BlogEtiket entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
            return(entity.BlogEtiketID);
        }

        public void Delete(BlogEtiket entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public void RemoveBlogEtiketler(int blogID)
        {
            var blogEtiketler = _dataContext.BlogEtiketler.Where(be => be.BlogID == blogID).ToList();
            _dataContext.BlogEtiketler.RemoveRange(blogEtiketler);
            _dataContext.SaveChanges();
        }

        public BlogEtiket GetByID(int id)
        {
            return _dataContext.Set<BlogEtiket>().Find(id);
        }

        public List<BlogEtiket> GetListAll()
        {
            return _dataContext.Set<BlogEtiket>().ToList();
        }

        public void Update(BlogEtiket entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
