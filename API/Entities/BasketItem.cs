using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;
[Table("BasketItem")]
public class BasketItem
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    //navigation properties
    public int ProductId { get; set; }
    public required Product Product { get; set; } //1-1 relationship with product

    public int BasketId { get; set; }
    public Basket Basket { get; set; } =null!;//1-1 relationship with basket



}