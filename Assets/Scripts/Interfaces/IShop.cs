﻿using Tools;

namespace GBMobile.Shop
{
    public interface IShop
    {
        void Buy(string id);

        string GetCost(string productID);

        void RestorePurchase();

        IReadOnlySubscriptionAction OnSuccessPurchase { get; }

        IReadOnlySubscriptionAction OnFailedPurchase { get; }


    }
}