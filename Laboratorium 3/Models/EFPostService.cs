using Data.Entities;
using Data;

namespace Laboratorium_3.Models
{
    public class EFPostService : IPostService
    {
        private AppDbContext _context;

        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post contact)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(contact));
            e.Entity.PostDate = DateTime.Now;
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            return _context.Posts.Select(e => PostMapper.FromEntity(e)).ToList(); ;
        }

        public Post? FindById(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            return find == null ? null : PostMapper.FromEntity(find);
        }

        public void Update(Post post)
        {
            PostEntity entity = PostMapper.ToEntity(post);
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
