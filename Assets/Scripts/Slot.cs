using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private TMP_Text _text;
    public VectorData _vectorData;

    void Start()
    {
        _text.text = $"({_vectorData._row},{_vectorData._col})";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _normalColor;
    }

    public struct VectorData
    {
        public int _row;
        public int _col;
    }
}
