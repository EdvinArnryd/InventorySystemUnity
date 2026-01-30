using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Pool;

public enum NotificationItemType
{
    Weapon,
    Upgrade,
    Crate,
    Contract,
    Undefined
}

public class NotificationManager : MonoBehaviour
{
    [Header("Default Data Settings")]
    [SerializeField] private string _defaultTitleText = "Notification";
    [SerializeField] private string _defaultDescriptionText = "Added to inventory";
    [SerializeField] private Sprite _defaultSprite;

    [SerializeField] private Color _weaponColor;
    [SerializeField] private Color _upgradeColor;
    [SerializeField] private Color _crateColor;
    [SerializeField] private Color _contractColor;
    [SerializeField] private Color _undefinedColor;

    [SerializeField] private NotificationUI _notificationPrefab;
    [SerializeField] private Transform _notificationTransform;

    private IObjectPool<NotificationUI> _notificationPool;
    private int _activeNotifications = 0;
    [SerializeField] private int _queueSize = 3;
    private Queue<NotificationData> _notificationQueue;
    public static NotificationManager _Instance { get; private set; }

    private void Awake()
    {
        _notificationQueue = new Queue<NotificationData>();
        // Singleton pattern for easy access
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
            CreatePool();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// Adds notification object to queue with title, description and sprite
    /// </summary>
    /// <param name="title">Title of the notification</param>
    /// <param name="description">Description of the notification</param>
    /// <param name="sprite">The sprite of the notification</param>
    /// <param name="itemType">The specific item</param>
    public void AddNotificationToQueue(string title, string description, Sprite sprite, NotificationItemType itemType)
    {
        NotificationData notifData = new NotificationData
        {
            title = title,
            description = description,
            sprite = sprite,
            color = ColorGenerator(itemType)
        };

        _notificationQueue.Enqueue(notifData);

        if(_activeNotifications < _queueSize)
            SpawnNotification();
    }

    /// <summary>
    /// Adds notification object to queue with title, description and itemType
    /// </summary>
    /// <param name="title">Title of the notification</param>
    /// <param name="description">Description of the notification</param>
    /// <param name="itemType">The specific item</param>
    public void AddNotificationToQueue(string title, string description, NotificationItemType itemType)
    {
        NotificationData notifData = new NotificationData
        {
            title = title,
            description = description,
            sprite = _defaultSprite,
            color = ColorGenerator(itemType)
        };

        _notificationQueue.Enqueue(notifData);

        if (_activeNotifications < _queueSize)
            SpawnNotification();
    }

    /// <summary>
    /// Adds notification object to queue with default data
    /// </summary>
    public void AddNotificationToQueue()
    {
        NotificationData notifData = new NotificationData
        {
            title = _defaultTitleText,
            description = _defaultDescriptionText,
            sprite = _defaultSprite,
            color = ColorGenerator(NotificationItemType.Undefined)
        };

        _notificationQueue.Enqueue(notifData);

        if (_activeNotifications < _queueSize)
            SpawnNotification();
    }

    /// <summary>
    /// Creates notification
    /// </summary>
    private void SpawnNotification()
    {
        if(_notificationQueue.Count > 0)
        {
            NotificationUI ui = _notificationPool.Get();
            NotificationData notifData = _notificationQueue.Dequeue();

            ui.Setup(new NotificationData
            {
                title = notifData.title,
                description = notifData.description,
                sprite = notifData.sprite,
                color = notifData.color
            });
        }
    }

    /// <summary>
    /// Returns the color based on the item type
    /// </summary>
    private Color ColorGenerator(NotificationItemType item)
    {
        switch(item)
        {
            case NotificationItemType.Weapon:
                return _weaponColor;
            case NotificationItemType.Upgrade:
                return _upgradeColor;
            case NotificationItemType.Crate:
                return _crateColor;
            case NotificationItemType.Contract:
                return _contractColor;
            case NotificationItemType.Undefined:
                return _undefinedColor;
            default:
                return _undefinedColor;
        }
    }

    private void CreatePool()
    {
        _notificationPool = new ObjectPool<NotificationUI>(
            CreateItem,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            collectionCheck: false,
            defaultCapacity: 0,
            maxSize: 3
        );
    }

    private NotificationUI CreateItem()
    {
        NotificationUI ui = Instantiate(_notificationPrefab, _notificationTransform);
        ui.SetPool(_notificationPool);
        ui.gameObject.SetActive(false);
        return ui;
    }

    private void OnTakeFromPool(NotificationUI ui)
    {
        _activeNotifications++;
        ui.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(NotificationUI ui)
    {
        _activeNotifications--;
        ui.ResetUI();
        ui.gameObject.SetActive(false);

        SpawnNotification();
    }

    private void OnDestroyPoolObject(NotificationUI ui)
    {
        Destroy(ui.gameObject);
    }

}
