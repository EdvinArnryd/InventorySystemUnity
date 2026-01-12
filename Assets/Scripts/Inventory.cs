using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns = 10;


    void Start()
    {
        InstantiateInventory();
    }

    private void InstantiateInventory()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Instantiate(_slot, transform);
            }
        }
    }
}
