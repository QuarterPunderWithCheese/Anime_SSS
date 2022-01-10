using System;
using System.Linq;
using DomainModel.Entities;

namespace DomainServices.Classes
{
    public class SubscriptionManager :ISubscriptionManager
    {
        private readonly IUserCatalog _catalog;
        private readonly AppDbContext _context;

        public SubscriptionManager(IUserCatalog catalog, AppDbContext context)
        {
            _context = context;
            _catalog = catalog;
        }

        public void AddSub(User user)
        {
            _context.Subscriptions.Add(new Subscription
            {
                User = user,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30)
            });
            _context.SaveChanges();
        }

        public bool CheckSub(User user)
        {
            var sub = _context.Subscriptions.FirstOrDefault(x => x.User == user);
            if (sub == null) return false;
            var result = sub.EndTime > DateTime.Now;
            if (result) return result;
            _context.Subscriptions.Remove(sub);
            return result;
        }
       
    }
}