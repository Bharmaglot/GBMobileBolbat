using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Item", order = 0)]

public class ItemConfig : ScriptableObject
{
    [SerializeField] public int Id;
    [SerializeField] public string Title;


}
