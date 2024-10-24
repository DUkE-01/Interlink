using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>
    {
        public PostService(IGenericRepository<Post> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
