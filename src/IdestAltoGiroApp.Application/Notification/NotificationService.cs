using FluentValidation;

namespace IdestAlgotGiroApp.Application.Notification;


public class NotificationService : INotificationService
{
    private List<Message> _notifications;

        public NotificationService()
        {
            _notifications = new List<Message>();
        }
    public bool Execute<TV, TE>(TV validation, TE entity)
        where TV : AbstractValidator<TE>
        where TE : class
    {
        var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            foreach (var item in validator.Errors)
            {
                Handle(new Message("", item.ErrorMessage));
            }

            return false;
    }

    public List<Message> GetNotifications()
    {
       return _notifications;
    }

    public void Handle(Message notificationMessage)
    {
        _notifications.Add(notificationMessage);
    }

    public bool HasNotification()
    {
        return _notifications.Any();
    }
}
