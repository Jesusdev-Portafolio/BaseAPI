using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender? Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<ISender>();

        private IMapper? _mapper;
        protected IMapper? Mapper => this._mapper ??= this.HttpContext.RequestServices.GetService<IMapper>();
    }

}
