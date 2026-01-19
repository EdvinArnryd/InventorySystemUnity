using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns = 10;
    [SerializeField] private List<Item> _startingItems;

    private Slot[,] _SlotGrid;


    void Awake()
    {
        _SlotGrid = new Slot[_rows, _columns];
        InstantiateInventory();
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ItemToolTip.Instance.gameObject.SetActive(false);
    }

    private void InstantiateInventory()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Slot newSlot = Instantiate(_slot, transform);

                _SlotGrid[i,j] = newSlot;
            }
        }

        for(int i = 0; i < _startingItems.Count; i++)
        {
            _SlotGrid[0,i].SetItem(_startingItems[i]);
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if(_SlotGrid[i,j].IsOccupied())
                {
                    continue;
                }
                else
                {
                    _SlotGrid[i,j].SetItem(item);
                    return;
                }
            }
        }
    }
}
