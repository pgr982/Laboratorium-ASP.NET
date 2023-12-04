using Data.Entities;

namespace Laboratorium_3.Models
{
    public class PostMapper
    {
        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.Id,
                Content = entity.Content,
                Autor = entity.Autor,
                PostDate = entity.PostDate,
                Tags = entity.Tags,
                Comment = entity.Comment,
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                Id = model.Id,
                Content = model.Content,
                Autor = model.Autor,
                PostDate = model.PostDate,
                Tags = model.Tags,
                Comment = model.Comment,
            };
        }
    }
}
