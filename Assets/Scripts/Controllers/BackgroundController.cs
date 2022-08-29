using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class BackgroundController : BaseController
    {
        private ResourcePath _prefabPath = new ResourcePath() { PathResource = "Prefabs/background" };

        private TapeBackgroundView _background;


        public BackgroundController(IReadOnlySubscriptionProperty<float> diff)
        {
            var prefab = ResourceLoader.LoadPrefab(_prefabPath);
            var gameObject = GameObject.Instantiate(prefab);
            _background = gameObject.GetComponent<TapeBackgroundView>();
            _background.Init(diff);
            AddGameObject(gameObject);
        }
    }
}
