namespace online_shop_backend.Models.DTO;

public class SubcategoryDto
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; }
    
    public string Icon { get; set; }

    public bool IsActual { get; set; }
}