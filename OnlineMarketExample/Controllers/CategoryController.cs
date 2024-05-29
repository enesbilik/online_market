using Application.Features.Category.Commands.Create;
using Application.Features.Category.Queries.GetCategoryList;

namespace OnlineMarketExample.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var getCategoryListQuery = new GetCategoryListQuery();
        var response = await Mediator.Send(getCategoryListQuery);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse response = await Mediator.Send(createCategoryCommand);
        return Ok(response);
    }
}