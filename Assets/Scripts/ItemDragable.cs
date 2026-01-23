using UnityEngine;
using UnityEngine.UI;

public class ItemDragable : MonoBehaviour
{
    public static ItemDragable Instance;
    [SerializeField] private Image _image;
    private Item _currentItem; 
    private Slot _currentSlot;
    private CanvasGroup _canvasGroup;

    private bool _isDragging;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        _canvasGroup = GetComponent<CanvasGroup>();
        Deactivate();
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
        _isDragging = true;
    }

    public void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _isDragging = false;
    }

    public void SetDraggingItem(Item item)
    {
        _currentItem = item;
        _image.sprite = item._Sprite;
    }

    public void SetCurrentSlot(Slot slot)
    {
        _currentSlot = slot;
    }

    public Slot GetCurrentSlot()
    {
        return _currentSlot;
    }

    public Item GetItem()
    {
        return _currentItem;
    }

    public bool GetIsDragging()
    {
        return _isDragging;
    }
}
