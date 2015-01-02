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
        [Route("register")]
        public Task<HttpResponseMessage> Register(CreateUserViewModel model)
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
                response = Request.CreateResponse(HttpStatusCode.BadRequest, Messages.FailedToCreateNewUser);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Authorize]
        [Route("changepassword")]
        public Task<HttpResponseMessage> ChangePassword(ChangePasswordViewModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangePassword(model.CurrentPassword, model.NewPassword, model.ConfirmPassword, User.Identity.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.ChangePasswordSuccess);
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, Messages.ChangePasswordFail);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("resetpassword")]
        public Task<HttpResponseMessage> ResetPassword(ResetPasswordViewModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ResetPassword(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, String.Format(Messages.ResetPasswordSuccess, model.Email));
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, Messages.ResetPasswordFail);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Authorize]
        [Route("update")]
        public Task<HttpResponseMessage> Update(UpdateProfileViewModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.UpdateProfile(model.Name, User.Identity.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.UpdateProfileSuccess);
            }
            catch (Exception ex)
            {
                _logService.Log(ex);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, Messages.UpdateProfileFail);
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
