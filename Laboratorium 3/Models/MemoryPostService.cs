namespace Laboratorium_3.Models
{
    public class MemoryPostService : IPostService
    {
        private Dictionary<int, Post> _items = new Dictionary<int, Post>();

        public int Add(Post item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.PostDate = DateTime.Now;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _items.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Post item)
        {
            _items[item.Id] = item;
        }
    }
}
