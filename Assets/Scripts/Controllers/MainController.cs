using System;
using UnityEngine;

namespace GBMobile
{
    public class MainController : BaseController
    {
        private readonly PlayerProfile _model;
        private readonly Transform _uiRoot;

        private BaseController _currentController;

        public MainController(PlayerProfile model, Transform uiRoot)
        {
            _model = model;
            _uiRoot = uiRoot;
            _model.State.SubscribeOnChange(OnGameStateChanged);
        }

        private void OnGameStateChanged(GameState state)
        {
            _currentController?.Dispose();
            switch (state)
            {
                case GameState.None:
                    break;
                case GameState.Menu:
                    _currentController = new MainMenuController(_model, _uiRoot);
                    AddController(_currentController);
                    break;
                case GameState.Game:
                    _currentController = new GameController(_model);
                    AddController(_currentController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}