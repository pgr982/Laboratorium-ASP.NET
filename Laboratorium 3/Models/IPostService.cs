namespace Laboratorium_3.Models
{
    public interface IPostService
    {
        int Add(Post post);
        void Delete(int id);
        void Update(Post post);
        List<Post> FindAll();
        Post? FindById(int id);
    }
}
