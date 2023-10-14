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

    [Test]
    public void Scan_AddsMultipleSameItemsToScannedItems()
    {
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(0));

        _checkout.Scan("A");
        _checkout.Scan("A");
        
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(2));
    }

      [Test]
    public void Scan_AddsMultipleDifferentItemsToScannedItems()
    {
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(0));
        Assert.That(_checkout.GetScannedItemQtyByItemId("B"), Is.EqualTo(0));

        _checkout.Scan("A");
        _checkout.Scan("B");
        
        Assert.That(_checkout.GetScannedItemQtyByItemId("A"), Is.EqualTo(1));
        Assert.That(_checkout.GetScannedItemQtyByItemId("B"), Is.EqualTo(1));
    }

}
