using UnityEngine;


[CreateAssetMenu(fileName = "New Item Data" , menuName = "Data/item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
}
