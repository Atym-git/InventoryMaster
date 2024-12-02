using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO",
 menuName = "SO/Items/New Inventory Item")]
public class InventoryItemSO : ScriptableObject
{
    [field:SerializeField]
    public string Name {  get; private set; }

    [field:SerializeField]
    public int Cost {  get; private set; }

    
}
