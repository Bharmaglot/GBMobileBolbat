using System.Collections.Generic;

namespace GBMobile.Items
{
    public interface IUpgradeableCar 
    {
        void SetSpeed(float speed);
        void Restore();
    }
}
