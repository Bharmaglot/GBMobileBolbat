using System;
using UnityEngine;
using System.Collections.Generic;
using GBMobile.Items;

namespace GBMobile
{
    public class MainController : BaseController
    {
        private readonly PlayerProfile _model;
        private readonly Transform _uiRoot;
        private List<ItemConfig> _itemConfigs;
        private List<UpgradeItemConfig> _upgrades { get; }

        private BaseController _currentController;


        public MainController(PlayerProfile model, Transform uiRoot, List<ItemConfig> itemConfigs, List<UpgradeItemConfig> upgrades)
        {
            _model = model;
            _uiRoot = uiRoot;
            _upgrades = upgrades;
            _model.State.SubscribeOnChange(OnGameStateChanged);
            _itemConfigs = itemConfigs;
        }

        private void OnGameStateChanged(GameState state)
        {
            _currentController?.Dispose();
            switch (state)
            {
                case GameState.None:
                    break;
                case GameState.Menu:
                    _currentController = new MainMenuController(_model, _uiRoot, _itemConfigs, _upgrades);
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