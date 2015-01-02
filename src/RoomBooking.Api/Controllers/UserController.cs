using RoomBooking.Api.Resources;
using RoomBooking.Api.ViewModels.User;
using RoomBooking.Core.Interfaces.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomBooking.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserService _service;
        private ILogService _logService;

        public UserController(IUserService service, ILogService logService)
        {
            this._service = service;
            this._logService = logService;
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post(CreateUserViewModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Register(model.Name, model.Email, model.Password, model.ConfirmPassword, model.Roles);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.FailedToCreateNewUser);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;            
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
