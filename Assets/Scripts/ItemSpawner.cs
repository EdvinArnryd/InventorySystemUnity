using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _startingItems;
    [SerializeField] private Button _spawnButton;
    [SerializeField] private Inventory _inventory;

    void Awake()
    {
        _spawnButton.onClick.AddListener(SpawnRandomItem);
    }

    private void SpawnRandomItem()
    {
        int random = Random.Range(0, _startingItems.Count - 1);
        Item item = _startingItems[random];

        _inventory.AddItem(item);
    }
}
