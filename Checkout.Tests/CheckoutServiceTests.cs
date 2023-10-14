using Checkout.Data;
using Checkout.Features;

namespace Checkout.Tests;

public class CheckoutServiceTests
{
    private const int priceA = 50;
    private const int priceB = 30;
    private const int specialPriceA = 130;
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

    [Test]
    public void Scan_ThrowsException_When_ItemNotFound()
    {
        Assert.Throws<Exception>(() => _checkout.Scan("Z"));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void GetTotalPrice_ShouldReturnCorrectPrice_whenSameItem(int itemsQty)
    {
        for (int i = 0; i < itemsQty; i++)
        {
            _checkout.Scan("A");
        }
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(itemsQty * priceA));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenDifferentItem(int itemsQty)
    {
        for (int i = 0; i < itemsQty; i++)
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
        }
        
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(itemsQty * priceA + itemsQty * priceB));
    }

    [Test]
    [TestCase(2)]
    // added static value for assertion to avoid mocking pricingData in interests of time
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenDifferentItem2(int itemsQty)
    {
        for (int i = 0; i < itemsQty; i++)
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
        }
        
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(145));
    }

    [Test]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenItemQtyIsSpecialOffer()
    {
       _checkout.Scan("A");
       _checkout.Scan("A");
       _checkout.Scan("A");

       Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(specialPriceA));
    }

    [Test]
    public void GetTotalPrice_ShouldReturnCorrectPrice_WhenItemQtyIncludesSpecialOfferButNotEqualTo()
    {
       _checkout.Scan("A");
       _checkout.Scan("A");
       _checkout.Scan("A");
       _checkout.Scan("A");

       Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(specialPriceA + priceA));
    }
}
