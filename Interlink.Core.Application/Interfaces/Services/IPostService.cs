﻿using Interlink.Core.Application.Services;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Domain.Entities;


namespace Interlink.Core.Application.Interfaces.Services
{
    public interface IPostService : IGenericService<SavePostViewModel,PostViewModel,Post>
    {
        Task<IEnumerable<PostViewModel>> GetAllPostsAsync();
    }
}