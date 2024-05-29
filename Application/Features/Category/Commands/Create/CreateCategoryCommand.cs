using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Category.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ICacheRemoverRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string? CacheKey => "GetCategoryList";
    public bool BypassCache => false;
    public string? CacheGroupKey => null;


    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request);
            category.Id = Guid.NewGuid();

            await _categoryRepository.AddAsync(category);
            var response = _mapper.Map<CreatedCategoryResponse>(category);

            return response;
        }
    }
}