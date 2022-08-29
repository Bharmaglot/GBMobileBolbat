using System;
using UnityEngine;
using Tools;

namespace GBMobile
{
    public class MainMenuController : BaseController
    {
        private ResourcePath _viewPath = new ResourcePath() { PathResource = "prefabs/mainMenu" };
       // private ResourcePath _touchViewPath = new ResourcePath() { PathResource = "prefabs/trailsTouch" };


        private readonly PlayerProfile _model;
        private readonly Transform _uiRoot;
        private TrailTouchView _trailView;

        public MainMenuController(PlayerProfile model, Transform uiRoot)
        {
            _model = model;
            _uiRoot = uiRoot;
           // _trailView.CreateTrailView(uiRoot);
            //_trailView.Init();
            CreateView();
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
            mainMenu.Init(StartGame);
        }

        private void StartGame()
        {
            _model.State.Value = GameState.Game;
        }
    }
}