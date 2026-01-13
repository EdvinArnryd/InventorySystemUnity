using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _columns = 10;
    [SerializeField] private List<Item> _startingItems;
    private List<Slot> _slotList;


    void Awake()
    {
        _slotList = new List<Slot>();
        InstantiateInventory();
    }
    void Start()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void InstantiateInventory()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Slot newSlot = Instantiate(_slot, transform);
                newSlot._vectorData._row = i;
                newSlot._vectorData._col = j;
                _slotList.Add(newSlot);
            }
        }

        for(int i = 0; i < _startingItems.Count; i++)
        {
            _slotList[i].SetItem(_startingItems[i]);
        }
    }
}
