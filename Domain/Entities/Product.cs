using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public int Stock { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsNew { get; set; }
    public bool IsSale { get; set; }

    public Product()
    {
        Id = Guid.NewGuid();
    }
}