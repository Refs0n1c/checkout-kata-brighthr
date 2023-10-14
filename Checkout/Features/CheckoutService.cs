namespace Checkout.Features;

public class CheckoutService : ICheckoutService
{
    public Dictionary<string, int> ScannedItems { get; set; } = new Dictionary<string, int>();

    public void Scan(string item)
    {
        ScannedItems.Add(item, 1);
    }
    
    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }

    public int GetScannedItemQtyByItemId(string itemId)
    {
        return ScannedItems.ContainsKey(itemId) ? ScannedItems[itemId] : 0;
    }

}
