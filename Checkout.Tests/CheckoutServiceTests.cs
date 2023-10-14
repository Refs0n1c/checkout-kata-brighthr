using Checkout.Features;

namespace Checkout.Tests;

public class CheckoutServiceTests
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
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(0));

        _checkout.Scan("A");
        
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(1));
    }

}
