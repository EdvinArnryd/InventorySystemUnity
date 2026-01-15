using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
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
        
        if(_item)
        {
            _image.color = _hoverColor;
            // Tooltip Logic
            // Activate Tooltip
            ItemToolTip.Instance.gameObject.SetActive(true);
            // Set Pos
            ItemToolTip.Instance.transform.position = Mouse.current.position.ReadValue();
            // Set Data
            ItemToolTip.Instance._titleText.text = _item._Name;
            ItemToolTip.Instance._descriptionText.text = _item._Description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_item)
        {
            _image.color = _normalColor;
            ItemToolTip.Instance.gameObject.SetActive(false);
        }
    }

    public struct VectorData
    {
        public int _row;
        public int _col;
    }

    public void ResetSlot()
    {
        _image.color = new Color(0,0,0,0);
    }

    public void SetItem(Item newItem)
    {
        _item = newItem;
        _image.sprite = _item._Sprite;
        _image.color = _normalColor;
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
