using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.Post;


namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<PostViewModel>> GetAllViewModelWithInclude();
    }
}
