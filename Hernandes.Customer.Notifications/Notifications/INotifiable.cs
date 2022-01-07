namespace Hernandes.Customer.Notifications.Notifications
{
    public interface INotifiable
    {
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}
