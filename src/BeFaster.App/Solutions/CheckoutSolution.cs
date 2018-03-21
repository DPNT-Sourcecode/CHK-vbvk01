using BeFaster.App.Checkout.Services;
using BeFaster.Runner.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            CheckoutService checkServ = new CheckoutService();

            return checkServ.ProcessBasket(skus);
        }
    }
}
