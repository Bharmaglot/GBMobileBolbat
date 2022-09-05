using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile
{
    public class BaseController : IDisposable
    {
        private bool _isDisposed = false;

        private List<BaseController> _childControllers = new List<BaseController>();
        private List<GameObject> _childGameObjects = new List<GameObject>();

        protected void AddController(BaseController controller) => _childControllers.Add(controller);
        protected void AddGameObject(GameObject gameObject) => _childGameObjects.Add(gameObject);

        protected virtual void OnDispose()
        {

        }

        public void Dispose()
        {
            if(!_isDisposed)
            {
                _isDisposed = true;
                OnDispose();

                foreach(var controller in _childControllers)
                {
                    controller?.Dispose();
                }
                _childControllers.Clear();

                foreach(var gameObject in _childGameObjects)
                {
                    if (gameObject != null)
                    {
                        GameObject.Destroy(gameObject);
                    }
                }
                _childGameObjects.Clear();

            }
        }
    }
}