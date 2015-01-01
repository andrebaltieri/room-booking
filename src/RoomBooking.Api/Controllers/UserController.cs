using RoomBooking.Core.Interfaces.Services;
using System.Web.Http;

namespace RoomBooking.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("teste")]
        public void Get()
        {
            _service.Authenticate("teste", "teste");
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
