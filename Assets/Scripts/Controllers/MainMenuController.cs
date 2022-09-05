using System;
using UnityEngine;
using Tools;
using UnityEngine.Purchasing;
using GBMobile.Shop;
using GBMobile.Items;
using System.Collections.Generic;


namespace GBMobile
{
    public class MainMenuController : BaseController
    {
        private ResourcePath _viewPath = new ResourcePath() { PathResource = "prefabs/mainMenu" };
       // private ResourcePath _touchViewPath = new ResourcePath() { PathResource = "prefabs/trailsTouch" };


        private readonly PlayerProfile _model;
        private readonly Transform _uiRoot;
        private TrailTouchView _trailView;
        private readonly List<ItemConfig> _configs;
        private readonly List<UpgradeItemConfig> _upgrades;

        private ShedController _shedController;

        public MainMenuController(PlayerProfile model, Transform uiRoot, List<ItemConfig> configs, List<UpgradeItemConfig> upgrades)
        {
            _model = model;
            _uiRoot = uiRoot; 
            _configs = configs;
            _upgrades = upgrades;
           // _trailView.CreateTrailView(uiRoot);
            //_trailView.Init();
            CreateView();

            _shedController = new ShedController(_model.CurrentCar, upgrades);
            _shedController.Enter();

        }

        //private TrailTouchView CreateTrailView(Transform uiRoot)
        //{
        //    var trailView = GameObject.Instantiate(ResourceLoader.LoadPrefab(_touchViewPath), _uiRoot, false).GetComponent<TrailTouchView>();
        //    AddGameObject(trailView.gameObject);
        //    return trailView;
        //}

        private void CreateView()
        {
            var prefab = ResourceLoader.LoadPrefab(_viewPath);
            var gameObject = GameObject.Instantiate(prefab, _uiRoot);
            AddGameObject(gameObject);
            var mainMenu = gameObject.GetComponent<MainMenuView>();
            mainMenu.Init(StartGame, OnPurchase);
            _model.Shop.OnSuccessPurchase.SubscribeOnChange(OnSuccesPurchase);
            _model.Shop.OnFailedPurchase.SubscribeOnChange(OnSuccesFailed);
        }

        private void OnPurchase()
        {
            Debug.Log("Button Click");
            _model.Shop.Buy("com.company.mygame.SmallGold");
        }


        private void OnSuccesPurchase()
        {
            Debug.Log("Succes purchase!");
        }

        private void OnSuccesFailed()
        {
            Debug.Log("Succes Failed!");
        }

        private void StartGame()
        {
            _model.State.Value = GameState.Game;
        }

        protected override void OnDispose()
        {
            _model.Shop.OnSuccessPurchase.SubscribeOnChange(OnSuccesPurchase);
            _model.Shop.OnFailedPurchase.SubscribeOnChange(OnSuccesFailed);
            base.OnDispose();
        }
    }
}