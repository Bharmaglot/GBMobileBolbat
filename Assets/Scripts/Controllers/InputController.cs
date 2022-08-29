using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class InputController : BaseController
    {
        private ResourcePath _prefabPath = new ResourcePath() { PathResource = "Prefabs/StickControl" };

        private BaseInputView _input;

        public InputController(SubscriptionProperty<float> diff, float speed)
        {
            var prefab = ResourceLoader.LoadPrefab(_prefabPath);
            var gameObject = GameObject.Instantiate(prefab);
            _input = gameObject.GetComponent<BaseInputView>();
            _input.Init(diff, speed);
            AddGameObject(gameObject);
        }
    }
}
