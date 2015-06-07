using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Helpers.Contracts;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomBooking.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IHandler<DomainNotification> Notification;
        public HttpResponseMessage ResponseMessage;

        public BaseController()
        {
            this.Notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            this.ResponseMessage = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (Notification.HasNotifications())
                ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = Notification.Notify() });
            else
                ResponseMessage = Request.CreateResponse(HttpStatusCode.OK, result);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(ResponseMessage);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            Notification.Dispose();
        }
    }
}