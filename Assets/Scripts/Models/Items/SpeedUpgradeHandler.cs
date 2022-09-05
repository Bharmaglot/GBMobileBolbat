using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items    
{
    public class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _newSpeed;
        public SpeedUpgradeHandler(float newSpeed)
        {
            _newSpeed = newSpeed;
        }

        public void Upgrade(IUpgradeableCar car)
        {
            car.SetSpeed(_newSpeed);
        }
    }
}