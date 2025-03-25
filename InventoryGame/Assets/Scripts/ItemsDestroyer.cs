using UnityEngine;

public class ItemsDestroyer : MonoBehaviour
{
    [SerializeField] private Transform itemsRootParent;

    [SerializeField] private ItemsFabric itemsFabric;

    public void DestroyItems(float from0To1Percentage)
    {
        if (from0To1Percentage > 0)
        {
            Mathf.Lerp(0, 1, from0To1Percentage);

            int childsAmount = itemsRootParent.childCount;

            int amountToDestroy = Mathf.RoundToInt(childsAmount * from0To1Percentage);

            for (int i = childsAmount; i > (childsAmount - amountToDestroy); i--)
            {
                Debug.Log(i);
                Debug.Log(itemsRootParent.GetChild(i-1).gameObject);
                Destroy(itemsRootParent.GetChild(i-1).gameObject);
            }
            itemsFabric.AllignAfterDestroy(amountToDestroy);
        }
    }
}
