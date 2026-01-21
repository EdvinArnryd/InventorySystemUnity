using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    private Item _item;
    private Slot _parentSlot;
    [SerializeField] private Image _image;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeginDrag();
        ItemDragable.Instance.Activate();
        ItemDragable.Instance.SetDraggingItem(_item);
        ItemDragable.Instance.SetCurrentSlot(_parentSlot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        ItemDragable.Instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemEndDrag();
        ItemDragable.Instance.Deactivate();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_item && !ItemDragable.Instance.GetIsDragging())
        {
            // Activate Tooltip
            ItemToolTip.Instance.Activate(_item);
            // Set Pos
            ItemToolTip.Instance.transform.position = eventData.position;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_item)
        {
            ItemToolTip.Instance.Deactivate();
        }
    }

    public void InitializeItem(Item item)
    {
        _item = item;
        _image.sprite = _item._Sprite;
    }

    public void ItemBeginDrag()
    {
        Color temp = _image.color;
        temp.a = 0.25f;
        _image.color = temp;
        _image.raycastTarget = false;
    }

    public void ItemEndDrag()
    {
        Color temp = _image.color;
        temp.a = 1f;
        _image.color = temp;
        _image.raycastTarget = true;
    }

    public Item GetItem()
    {
        return _item;
    }

    public void SetParentSlot(Slot slot)
    {
        _parentSlot = slot;
    }
}
