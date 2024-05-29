using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        Id = Guid.NewGuid();
    }
}