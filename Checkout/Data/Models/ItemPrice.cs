namespace Checkout.Data.Models;

public class ItemPrice
{
    public string Id { get; set; }
    public int UnitPrice { get; set; }
    public bool IsSpecialOffer { get; set; }
    public int SpecialOfferQty { get; set; }
    public int SpecialOfferTotalPrice { get; set; }

}