using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBMobile.Items
{
    public class UpgradeHandlerRepository : BaseController
    {

        public IReadOnlyDictionary<int, IUpgradeHandler> UpgradeItems => _upgradeItems;

        public UpgradeHandlerRepository(List<UpgradeItemConfig> configs)
        {
            PopulateItems(ref _upgradeItems, configs);
        }

        private void PopulateItems(ref Dictionary<int, IUpgradeHandler> upgradeItems, List<UpgradeItemConfig> upgradeItemConfigs)
        {
            upgradeItems = new Dictionary<int, IUpgradeHandler>();
            foreach (var upgrade in upgradeItemConfigs)
            {
                upgradeItems[upgrade.ItemConfig.Id] = CreateHandler(upgrade);
            }
        }

        private IUpgradeHandler CreateHandler(UpgradeItemConfig upgrade)
        {
            switch (upgrade.UpgradeType)
            {
                case UpgradeType.None:
                    return new StubUpgradehandler();
                case UpgradeType.Speed:
                    return new SpeedUpgradeHandler(upgrade.Value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private Dictionary<int, IUpgradeHandler> _upgradeItems;

    }


}