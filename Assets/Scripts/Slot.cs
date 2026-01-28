using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler
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
        if(IsOccupied())
        { 
            // Create Item Reference
            Item sourceItem = _currentItem.GetItem();
            Item draggedItem = ItemDragable.Instance.GetItem();

            // Destroy items in slots
            sourceSlot.DestroyItemUI();
            DestroyItemUI();

            // Create items
            sourceSlot.CreateItemUI(sourceItem);
            CreateItemUI(draggedItem);

            ItemDragable.Instance.Deactivate();
            return;

        }

        CreateItemUI(ItemDragable.Instance.GetItem());
        sourceSlot.DestroyItemUI();

        ItemDragable.Instance.Deactivate();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsOccupied())
        {
            print("This Slot is Occupied!");
        }
        else
        {
            print("This slot is free!");
        }
    }
}
