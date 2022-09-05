using System;
using UnityEngine;
using GBMobile.Shop;
using Tools;
using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace GBMobile
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform _uiRoot;
        [SerializeField] private List<ItemConfig> _itemConfigs;
        [SerializeField] private List<UpgradeItemConfig> _upgrades;





        [SerializeField] private List<ShopProduct> _products = new List<ShopProduct>()
        {
            new ShopProduct() 
            {
                CurrentProductType = ProductType.Consumable,
                Id = "com.company.mygame.SmallGold"
            }
        };

        private MainController _mainController;

        void Awake()
        {
            var model = new PlayerProfile(15f, new ShopTools(_products));
            _mainController = new MainController(model, _uiRoot, _itemConfigs, _upgrades);
            model.State.Value = GameState.Menu;
        }

        void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}