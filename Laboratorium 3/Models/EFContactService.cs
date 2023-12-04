using Data.Entities;
using Data;

namespace Laboratorium_3.Models
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            e.Entity.Created = DateTime.Now;
            _context.SaveChanges();
            int id = e.Entity.Id;
            return id;
        }


        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList(); ;
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);

            return find != null ? ContactMapper.FromEntity(find) : null;
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            int totalCount = _context.Contacts.Count();
            List<Contact> contacts = _context.Contacts
             .Skip((page - 1) * size)
             .Take(size)
             .Select(ContactMapper.FromEntity) // Użyj mappera do przekształcenia
             .ToList();
            return PagingList<Contact>.Create(contacts, totalCount, page, size);

        }

        public void Update(Contact contact)
        {
            ContactEntity entity = ContactMapper.ToEntity(contact);
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
