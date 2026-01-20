using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform _itemUISpawnTransform;
    [SerializeField] private ItemUI _itemUIPrefab;
    private ItemUI _currentItem;

    public void CreateItemUI(Item newItem)
    {
        ItemUI newUIItem = Instantiate(_itemUIPrefab, _itemUISpawnTransform);
        _currentItem = newUIItem;
        _currentItem.SetParentSlot(this);
        newUIItem.InitializeItem(newItem);
    }

    public bool IsOccupied()
    {
        if(_currentItem)
        {
            return true;
        }
        return false;
    }

    private void DestroyItemUI()
    {
        Destroy(_currentItem.gameObject);
        _currentItem = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Slot sourceSlot = ItemDragable.Instance.GetCurrentSlot();
        
        if(sourceSlot == this) return;
        if(IsOccupied()) return;

        CreateItemUI(ItemDragable.Instance.GetItem());
        sourceSlot.DestroyItemUI();

        ItemDragable.Instance.Deactivate();
    }
}
