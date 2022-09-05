using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using GBMobile;

namespace GBMobile.Items
{
    public class ShedController : BaseController, IShedController
    {
        private Car _car;
        private readonly List<UpgradeItemConfig> _configs;

        private IInventoryModel _inventoryModel;
        private IItemsRepository _itemsRepository;
        private IInventoryController _inventoryController;
        private IInventoryView _inventoryView;
        private UpgradeHandlerRepository _upgradeHandlerRepository;

        public ShedController(Car car, List<UpgradeItemConfig> configs)
        {  
            _car = car;
            _configs = configs;

            var repository = new ItemRepository(configs.Select(c=>c.ItemConfig).ToList());
            AddController(repository);
            _itemsRepository = repository;
            _inventoryModel = new InventoryModel();
            _inventoryView = new InventoryView();
            var inventory = new InventoryController(_inventoryModel, _itemsRepository, _inventoryView);
            AddController(inventory);
            var upgrades = new UpgradeHandlerRepository(configs);
            AddController(upgrades);
            _upgradeHandlerRepository = upgrades;
            _inventoryController = inventory;
            _inventoryController.ShowInventory();
        }

        public void Enter()
        {
            _car.Restore();
            Debug.Log($"Shed enter: car speed = {_car.Speed}");
        }

        public void Exit()
        {
            foreach (var item in _itemsRepository.Items.Values)
            {
                _inventoryModel.Equip(item);
            }
            UpgradeCarWithEquiped(_inventoryModel, _car);
            Debug.Log($"Shed exit: car speed = {_car.Speed}");
        }

        private void UpgradeCarWithEquiped(IInventoryModel inventoryModel, Car car)
        {
            foreach(var item in inventoryModel.GetEquipedItems())
            {
                if(_upgradeHandlerRepository.UpgradeItems.TryGetValue(item.Id, out var handler))
                {
                    handler.Upgrade(car);
                }
            }
        }
    }
}
