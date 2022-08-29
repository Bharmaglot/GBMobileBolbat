using System;
using UnityEngine;

namespace GBMobile
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform _uiRoot;

        private MainController _mainController;

        void Start()
        {
            var model = new PlayerProfile(1f);
            _mainController = new MainController(model, _uiRoot);
            model.State.Value = GameState.Menu;
        }

        void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}