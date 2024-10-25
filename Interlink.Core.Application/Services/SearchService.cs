using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Search;
using Interlink.Core.Domain.Entities;
using AutoMapper;
using Interlink.Core.Application.Services;

public class SearchService : GenericService<SaveSearchViewModel, SearchResultViewModel, SearchResult>, ISearchService
{
    private readonly ISearchRepository _searchRepository;
    private readonly IMapper _mapper;

    public SearchService(ISearchRepository searchRepository, IMapper mapper) : base(searchRepository, mapper)
    {
        _searchRepository = searchRepository;
        _mapper = mapper;
    }

    public async Task<List<SearchResultViewModel>> SearchPostsAsync(string query)
    {
        var results = await _searchRepository.SearchPostsAsync(query);
        return results.Select(r => _mapper.Map<SearchResultViewModel>(r)).ToList();
    }
}
