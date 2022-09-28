using DixitOnline.ServiceResulting;
using Microsoft.AspNetCore.Mvc;

namespace DixitOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultingController : ControllerBase
    {
        protected AbstractServiceResult ValidateModel<TModel>()
            => ModelState.IsValid
                ? new GenericServiceResult<TModel>().Success()
                : new GenericServiceResult<TModel>().Fail();

        protected AbstractServiceResult ValidateModel()
            => ModelState.IsValid
                ? new ServiceResult().Success()
                : new ServiceResult().Fail();
    }
}
