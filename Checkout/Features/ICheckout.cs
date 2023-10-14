namespace Checkout.Features;

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}