namespace VetCare.API.Store.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Image { get; set; }
    public int Stock { get; set; }
}