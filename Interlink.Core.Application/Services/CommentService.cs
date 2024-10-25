using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Comment;
using Interlink.Core.Domain.Entities;
using AutoMapper;
using Interlink.Core.Application.Services;

public class CommentService : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper) : base(commentRepository, mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentViewModel>> GetCommentsByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
        return comments.Select(c => _mapper.Map<CommentViewModel>(c)).ToList();
    }

    public async Task DeleteCommentAsync(int id)
    {
        await Delete(id);
    }
}
