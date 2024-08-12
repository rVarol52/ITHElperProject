using ITHelper.Infranstrucure.Entities;

namespace ITHelper.Application.Business.Services.Interfaces
{
    public interface IBlogService<T>: IService<Blog>
    {
        List<Blog> GetBlogsByEtiketler(List<int> etiketler);
        void ArtirOkunmaSayisi(int BlogID);
    }
}
