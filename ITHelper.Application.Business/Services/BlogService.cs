using ITHelper.Application.Business.Services.Interfaces;
using ITHelper.Infranstrucure.DataContext;
using Microsoft.EntityFrameworkCore;
using ITHelper.Infranstrucure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Business.Services
{
    public class BlogService : IBlogService<Blog>
    {

        private readonly ITHelperContext _dataContext;

        public BlogService(ITHelperContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(Blog entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
            return entity.BlogID;
        }

        public void ArtirOkunmaSayisi(int BlogID)
        {
            var blog = _dataContext.Bloglar.FirstOrDefault(b => b.BlogID == BlogID);
            if (blog != null)
            {
                blog.OkunmaSayisi += 1;
                _dataContext.Update(blog);
                _dataContext.SaveChanges();
            }
        }

        public void Delete(Blog entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public List<Blog> GetBlogsByEtiketler(List<int> etiketler)
        {
            var de = _dataContext.BlogEtiketler.Where(x=>etiketler.Contains(x.EtiketID)).Select(x=>x.BlogID).ToList();
            var blogs = _dataContext.Bloglar
                .Include(a => a.OlusturanKullanici)
                .Include(a=>a.BlogEtiketler)
                .ThenInclude(a=>a.Etiket)
                .Where(a=>de.Contains(a.BlogID))
                .ToList();

            return blogs;
        }

        public Blog GetByID(int id)
        {
            return _dataContext.Set<Blog>()
                .Include(b => b.OlusturanKullanici)
                .Include(b=> b.BlogEtiketler)
                .ThenInclude(a=> a.Etiket)
                .FirstOrDefault(b => b.BlogID == id);

        }

        public List<Blog> GetListAll()
        {
            return _dataContext.Set<Blog>().Include(b => b.OlusturanKullanici).ToList();
        }

        public void Update(Blog entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
