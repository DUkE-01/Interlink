using AutoMapper;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.Services;

public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
        : base(postRepository, mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostViewModel>> GetAllViewModelWithInclude()
    {
        var posts = await _postRepository.GetAllViewModelWithInclude();

        var postViewModels = posts
            .Select(post => _mapper.Map<PostViewModel>(post))
            .ToList();

        return postViewModels;
    }

    public override async Task<SavePostViewModel> GetByIdSaveViewModel(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        return _mapper.Map<SavePostViewModel>(post);
    }

    public async Task<SavePostViewModel> Add(SavePostViewModel vm, int userId)
    {
        var post = _mapper.Map<Post>(vm);
        post.UserId = userId;

        post = await _postRepository.AddAsync(post);

        return _mapper.Map<SavePostViewModel>(post);
    }

    public override async Task Update(SavePostViewModel vm, int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        if (post != null)
        {
            post = _mapper.Map(vm, post);
            await _postRepository.UpdateAsync(post, id);
        }
    }
}
