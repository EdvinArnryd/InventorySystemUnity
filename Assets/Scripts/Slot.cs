using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Item _item;
    public VectorData _vectorData;

    void Start()
    {
        ItemToolTip.Instance.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _hoverColor;
        if(_item)
        {
            // Tooltip Logic
            // Activate Tooltip
            ItemToolTip.Instance.gameObject.SetActive(true);
            // Set Pos
            ItemToolTip.Instance.transform.position = transform.position;
            // Set Data
            ItemToolTip.Instance._titleText.text = _item._Name;
            ItemToolTip.Instance._descriptionText.text = _item._Description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _normalColor;
        if (_item)
        {
            ItemToolTip.Instance.gameObject.SetActive(false);
        }
    }

    public struct VectorData
    {
        public int _row;
        public int _col;
    }

    public void SetItem(Item newItem)
    {
        _item = newItem;
        _image.sprite = _item._Sprite;
    }
}
