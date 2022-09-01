using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools; 
using GBMobile.Shop;


namespace GBMobile
{
    public class PlayerProfile
    {
        public Car Car { get; private set; }
        public SubscriptionProperty<GameState> State { get; private set; }
        public IShop Shop { get; private set; }


        public PlayerProfile(float speed, IShop shop)
        { 
            Car = new Car(speed);
            State = new SubscriptionProperty<GameState>();
            Shop = shop;
        }
    }

    public enum GameState
    {
        None,
        Menu,
        Game,
    }
}