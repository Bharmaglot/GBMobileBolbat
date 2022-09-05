using System.Collections.Generic;

namespace GBMobile.Items
{
    public interface IUpgradeHandler
    {
        void Upgrade(IUpgradeableCar car);
    }
}