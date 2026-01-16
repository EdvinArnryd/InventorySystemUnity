using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemDragable : MonoBehaviour
{
    public static ItemDragable Instance;
    [SerializeField] public Image _image;
    public bool _isDragging;
    public bool _isHovering;
    private Item _item; 
    private CanvasGroup _canvasGroup;

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

    private void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
        if (_isHovering)
        {
            if (Mouse.current.leftButton.IsPressed())
            {
                StartDraggingItem();
            }
        }
    }

    public void ItemHovered(Item item)
    {
        _item = item;
    }

    public void StartDraggingItem()
    {
        _isDragging = true;
        _image.sprite = _item._Sprite;
        Activate();
    }

    public Item DropItem()
    {
        StopDragging();
        return _item;
    }
    
    public void StopDragging()
    {
        _isDragging = false;
    }

    private void Activate()
    {
        _canvasGroup.alpha = 1;
    }

    private void Deactivate()
    {
        _canvasGroup.alpha = 0;
    }
}
