using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO",
 menuName = "SO/Items/New Inventory Item")]
public class InventoryItemSO : ScriptableObject
{
    [field:SerializeField]
    public string Name {  get; private set; }

    [field: SerializeField]
    public string Class { get; private set; }

    [field:SerializeField]
    public int Cost {  get; private set; }

    [field: SerializeField]
    public int Stats { get; private set; }
    [field: SerializeField]
    public Sprite Sprite { get; private set; }
    [field: SerializeField]
    public float DestroyInPercentsFrom0To1 { get; private set; }
}