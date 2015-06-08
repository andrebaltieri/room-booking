using RoomBooking.ApplicationService.Account.Handlers;
using RoomBooking.Domain.Account.Commands.UserCommands;
using RoomBooking.Domain.Account.Services;
using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Helpers.Contracts;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomBooking.Api.Controllers
{
    public class ValuesController : BaseController
    {        
        private readonly IUserApplicationService _service;

        public ValuesController(IUserApplicationService service)
        {            
            this._service = service;       
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                username: (string)body.username,
                password: (string)body.password
            );
            
            _service.Register(command);

            return CreateResponse(HttpStatusCode.OK, command);
        }
    }
}