using DixitOnline.ServiceResulting;
using Microsoft.AspNetCore.Mvc;

namespace DixitOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultingController : ControllerBase
    {
        protected ServiceResult<TModel> ValidateModel<TModel>()
            => ModelState.IsValid
                ? new ServiceResult<TModel>().Success()
                : new ServiceResult<TModel>().Fail();

        protected ServiceResult<Empty> ValidateModel()
            => ModelState.IsValid
                ? new ServiceResult<Empty>().Success()
                : new ServiceResult<Empty>().Fail();
    }
}
