using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragable : MonoBehaviour
{
    public static ItemDragable Instance;
    [SerializeField] private Image _image;
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
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
    }

    public void Deactivate()
    {
        _canvasGroup.alpha = 0;
    }

    public void SetDraggingItem(Item item)
    {
        _item = item;
        _image.sprite = _item._Sprite;
    }
}
