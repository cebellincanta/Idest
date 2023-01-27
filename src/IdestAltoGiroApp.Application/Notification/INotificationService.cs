using FluentValidation;

namespace IdestAlgotGiroApp.Application.Notification;

public interface INotificationService
{
    bool HasNotification();
        List<Message> GetNotifications();
        void Handle(Message notificationMessage);
        bool Execute<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class;
}