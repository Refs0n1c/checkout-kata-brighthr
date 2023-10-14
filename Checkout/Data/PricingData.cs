using Checkout.Data.Models;

namespace Checkout.Data;

public static class PricingData
{
    //IRL this would be from a DB but in the interests of time, im not going to implemented a inMemory DB EF implementation
    public static List<ItemPrice> ItemPrices { get; } = new List<ItemPrice>
    { 
        new ItemPrice 
        {
            Id = "A",
            UnitPrice = 50,
            SpecialOfferQty = 3,
            IsSpecialOffer = true,
            SpecialOfferTotalPrice = 130
        },
        new ItemPrice 
        {
            Id = "B",
            UnitPrice = 30,
            SpecialOfferQty = 2,
            IsSpecialOffer = true,
            SpecialOfferTotalPrice = 45
        },
         new ItemPrice 
         {
            Id = "C",
            UnitPrice = 20,
            SpecialOfferQty = 0,
            IsSpecialOffer = false,
            SpecialOfferTotalPrice = 0
        },
        new ItemPrice 
        {
            Id = "D",
            UnitPrice = 15,
            SpecialOfferQty = 0,
            IsSpecialOffer = false,
            SpecialOfferTotalPrice = 0
        }
    };
}
