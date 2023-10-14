namespace Checkout.Features;

public interface ICheckoutService
{
    void Scan(string item);
    int GetTotalPrice();

    int GetScannedItemQtyByItemId(string itemId);
}