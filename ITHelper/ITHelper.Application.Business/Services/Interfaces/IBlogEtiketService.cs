using ITHelper.Infranstrucure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Business.Services.Interfaces
{
    public interface IBlogEtiketService<T> : IService<BlogEtiket> 
    {
        void RemoveBlogEtiketler(int blogID);
    }
}
