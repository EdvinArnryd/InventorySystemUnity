using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Transform _itemUISpawnTransform;
    [SerializeField] private Item _item;
    [SerializeField] private ItemUI _itemUIPrefab;

    public void SetItem(Item newItem)
    {
        _item = newItem;
        ItemUI newUIItem = Instantiate(_itemUIPrefab, _itemUISpawnTransform);
        newUIItem.InitializeItem(_item);
    }

    public bool IsOccupied()
    {
        if(_item)
        {
            return true;
        }
        return false;
    }
}
