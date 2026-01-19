using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    private Item _item;
    [SerializeField] private Image _image;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Color temp = _image.color;
        temp.a = 0.25f;
        _image.color = temp;
        _image.raycastTarget = false;
        ItemDragable.Instance.Activate();
        ItemDragable.Instance.SetDraggingItem(_item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        ItemDragable.Instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Color temp = _image.color;
        temp.a = 1f;
        _image.color = temp;
        _image.raycastTarget = true;
        ItemDragable.Instance.Deactivate();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_item)
        {
            // Tooltip Logic
            // Activate Tooltip
            ItemToolTip.Instance.gameObject.SetActive(true);
            // Set Pos
            ItemToolTip.Instance.transform.position = eventData.position;
            // Set Data
            ItemToolTip.Instance._titleText.text = _item._Name;
            ItemToolTip.Instance._descriptionText.text = _item._Description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_item)
        {
            ItemToolTip.Instance.gameObject.SetActive(false);
        }
    }

    public void InitializeItem(Item item)
    {
        _item = item;
        _image.sprite = _item._Sprite;
    }
}
