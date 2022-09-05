using UnityEngine;
using GBMobile.Items;

    [CreateAssetMenu(fileName = "Upgrade Item", menuName = "Upgrade Item", order = 1)]



    public class UpgradeItemConfig : ScriptableObject
{
    public ItemConfig ItemConfig;
    public UpgradeType UpgradeType;
    public float Value;
}




