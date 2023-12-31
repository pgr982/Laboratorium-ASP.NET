﻿using Data.Entities;

namespace Laboratorium_3.Models
{
    public class MemoryContactService : IContactService
    {
        IDateTimeProvider _timeProvider;

        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();


        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public int Add(Contact item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.Created = _timeProvider.GetDateTime();
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return new List<Contact>() { new Contact() { Id = 1} };
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            throw new NotImplementedException();
        }

        public Contact? FindById(int id)
        {   
            if (_items.ContainsKey(id))
            {
                return _items[id];
            }
            return null;
        }

        public PagingList<Contact> FindPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }
    }
}
