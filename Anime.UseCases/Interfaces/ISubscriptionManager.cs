using DomainModel.Entities;

namespace DomainServices
{
    public interface ISubscriptionManager
    {
        void AddSub(User user);
        bool CheckSub(User user);
    }
}