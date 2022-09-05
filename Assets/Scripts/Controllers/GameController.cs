using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class GameController : BaseController
    {
        private readonly PlayerProfile _model;

        public GameController(PlayerProfile model)
        {
            _model = model;


            var diff = new SubscriptionProperty<float>();

            var background = new BackgroundController(diff);
            AddController(background);
            var car = new CarController();
            AddController(car);
            var input = new InputController(diff, model.Car.Speed);
            AddController(input);
        }

    }
}