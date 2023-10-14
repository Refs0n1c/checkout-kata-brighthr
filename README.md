# checkout-kata-brighthr

Thanks for looking at my test!

Some considerations made during:

1. PricingData is a static class, there is a requirement at the bottom of the tasks requirements that say we should be able to inject new pricing rules.
is would need to be refactored in order to be a non static class and its interface injected into the CheckoutService.
2. There were a couple of tests where I had to use a satic expected value as I couldnt fiigure out how to mock my pricingdata static class ( Moq cant use static classes).
3. I could of found a way around this but I ran out of time.
