using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBMobile.Items;

namespace GBMobile
{
    public class Car: IUpgradeableCar
    {
        public float Speed { get; private set; }

        public float _baseSpeed;

        public Car(float speed)
        {
            _baseSpeed = speed;
            Restore();
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public void Restore()
        {
            Debug.Log("car restore");
            Speed = _baseSpeed;
        }
        
    }
}