using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.CommentReply;
using Interlink.Core.Domain.Entities;
using AutoMapper;
using Interlink.Core.Application.Services;

public class CommentReplyService : GenericService<SaveCommentReplyViewModel, CommentReplyViewModel, CommentReply>, ICommentReplyService
{
    private readonly ICommentReplyRepository _commentReplyRepository;
    private readonly IMapper _mapper;

    public CommentReplyService(ICommentReplyRepository commentReplyRepository, IMapper mapper) : base(commentReplyRepository, mapper)
    {
        _commentReplyRepository = commentReplyRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentReplyViewModel>> GetRepliesByCommentIdAsync(int commentId)
    {
        var replies = await _commentReplyRepository.GetRepliesByCommentIdAsync(commentId);
        return replies.Select(r => _mapper.Map<CommentReplyViewModel>(r)).ToList();
    }

    public async Task DeleteReplyAsync(int id)
    {
        await Delete(id);
    }
}
