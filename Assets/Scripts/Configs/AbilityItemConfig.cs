using UnityEngine;
using GBMobile.Items;

[CreateAssetMenu(fileName = "AbilityItem", menuName = "Ability item", order = 0)]

public class AbilityItemConfig : ScriptableObject
{
    public ItemConfig ItemConfig;
    public GameObject View;
    public AbilityType AbilityType;
    public float Value;
    public int Id => ItemConfig.Id;
}
