using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<GetCategoryListItemDto>>, ICacheableRequest
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<GetCategoryListItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryListItemDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<GetCategoryListItemDto>>(categories);
        }
    }

    public string CacheKey => "GetCategoryList";
    public bool BypassCache => false;
    public TimeSpan? SlidingExpiration { get; }
    public string? CacheGroupKey => null;
}