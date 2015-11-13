using Danse.Models.Entities;
using Danse.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danse.Models.AccessBd
{
    public class MessengerRepository : IMessengerRepository
    {
        private StoreDB _store = new StoreDB();

        public MessengerRepository()
        {

        }

        public IEnumerable<Messenger> GetAll()
        {
            return _store.Messenger;
        }

        public Messenger Get(int id)
        {
            return _store.Messenger.Where(u => u.MessengerId.Equals(id)).FirstOrDefault();
        }

        public Messenger Add(Messenger message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            _store.Messenger.Add(message);
            _store.SaveChanges();
            return message;
        }

        public void Remove(int id)
        {
            Messenger message = new Messenger();
            message = _store.Messenger.Where(c => c.MessengerId.Equals(id)).FirstOrDefault();
            _store.Messenger.Remove(message);
            _store.SaveChanges();
        }

        public bool Update(Messenger message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            Messenger currentMessage = _store.Messenger.Where(c => c.MessengerId.Equals(message.MessengerId)).FirstOrDefault();
            if (currentMessage == null)
            {
                return false;
            }
            _store.Entry(currentMessage).State = System.Data.Entity.EntityState.Modified;
            _store.SaveChanges();
            return true;
        }
    }
}