using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Search;
using Microsoft.AspNetCore.Mvc;


namespace Interlink.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IActionResult> Index(string query)
        {
            // Verificamos si el query de búsqueda está vacío
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<SearchResultViewModel>());
            }

            
            var searchResults = await _searchService.SearchPostsAsync(query);

            
            var processedResults = searchResults.Select(result => new
            {
                result.Id,
                result.UserId,
                result.User,
                result.SearchQuery,
                result.SearchedAt,
                Posts = result.Posts.Select(post => new
                {
                    post.Content,    
                    post.CreatedAt,
                    post.Comments
                })
            }).ToList();

            return View(processedResults);
        }
    }
}
