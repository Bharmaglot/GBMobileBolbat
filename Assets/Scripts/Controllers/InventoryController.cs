using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GBMobile.Items
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _model;
        private readonly IItemsRepository _repository;
        private readonly IInventoryView _view;


        public InventoryController(IInventoryModel model, IItemsRepository repository, IInventoryView view)
        {
            _model = model;
            _repository = repository;
            _view = view;
        }

        public void ShowInventory()
        {
           foreach(var item in _repository.Items.Values)
            {
                _model.Equip(item);
            }
            _view.Display(_model.GetEquipedItems());
        }

        public void HideIbentory()
        {

        }
    }
}
