using Checkout.Features;

namespace Checkout.Tests;

public class CheckoutTests
{
    private ICheckoutService _checkout;

    [SetUp]
    public void Setup()
    {
        _checkout = new CheckoutService();
    }

    [Test]
    public void Scan_AddsToScannedItems()
    {
        _checkout.Scan("A");
    }

}
