using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class CarController : BaseController
    {
        private ResourcePath _prefabResourse = new ResourcePath() { PathResource = "Prefabs/Car" };

        private CarView _car;

        public CarController()
        {
            var prefab = ResourceLoader.LoadPrefab(_prefabResourse);
            var gameObject = GameObject.Instantiate(prefab);
            _car = gameObject.GetComponent<CarView>();
            AddGameObject(gameObject);
        }
    }
}