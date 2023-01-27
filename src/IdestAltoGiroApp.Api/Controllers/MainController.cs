using IdestAlgotGiroApp.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdestAlgotGiroApp.Api.Controllers;

public class MainController : ControllerBase
{
    private readonly INotificationService _notification;

    public MainController(INotificationService notification)
    {
        _notification = notification;
    }
          protected bool ValidOperation()
        {
            return !_notification.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notification.GetNotifications()
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModel(modelState);

            return CustomResponse();
        }

        protected void NotifyInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(x => x.Value.Errors.Count > 0).ToList();
            foreach (var erro in errors)
            {
                ErrorNotifier(erro.Key, erro.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
            }
        }

        protected void ErrorNotifier(string property, string message)
        {
            _notification.Handle(new Message(property, message));
        }
    }
