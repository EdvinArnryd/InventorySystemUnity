using UnityEngine;
using UnityEngine.UI;

public class Spawn2DItem : MonoBehaviour
{
    [SerializeField] private Item _startingItem;
    [SerializeField] private Button _spawnButton;
    [SerializeField] private Inventory _inventory;

    void Awake()
    {
        _spawnButton.onClick.AddListener(SpawnItem);
    }

    private void SpawnItem()
    {
        _inventory.Add2DItem(_startingItem);
    }
}
