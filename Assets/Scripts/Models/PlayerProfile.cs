using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class PlayerProfile
    {
        public Car Car { get; private set; }
        public SubscriptionProperty<GameState> State { get; private set; }

        public PlayerProfile(float speed)
        {
            Car = new Car(speed);
            State = new SubscriptionProperty<GameState>();
        }
    }

    public enum GameState
    {
        None,
        Menu,
        Game,
    }
}