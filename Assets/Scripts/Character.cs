using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Slot _slotPrefab;
    [SerializeField] private ItemUI _itemUIPrefab;
    [SerializeField] private Item _item;

    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _shoulders;
    [SerializeField] private GameObject _neck;
    [SerializeField] private GameObject _ring;
    [SerializeField] private GameObject _hands;
    [SerializeField] private GameObject _torso;
    [SerializeField] private GameObject _waist;
    [SerializeField] private GameObject _feet;
    [SerializeField] private GameObject _weapon;

    void Awake()
    {
        CreateCharacterSlots();
    }

    private void CreateCharacterSlots()
    {
        Slot headSlot = Instantiate(_slotPrefab, _head.transform);
        headSlot.SetItemSlotType(ItemType.Head);

        Slot shouldersSlot = Instantiate(_slotPrefab, _shoulders.transform);
        shouldersSlot.SetItemSlotType(ItemType.Shoulders);

        Slot neckSlot = Instantiate(_slotPrefab, _neck.transform);
        neckSlot.SetItemSlotType(ItemType.Neck);

        Slot ringSlot = Instantiate(_slotPrefab, _ring.transform);
        ringSlot.SetItemSlotType(ItemType.Ring);

        Slot handsSlot = Instantiate(_slotPrefab, _hands.transform);
        handsSlot.SetItemSlotType(ItemType.Hands);

        Slot torsoSlot = Instantiate(_slotPrefab, _torso.transform);
        torsoSlot.SetItemSlotType(ItemType.Torso);

        Slot waistSlot = Instantiate(_slotPrefab, _waist.transform);
        waistSlot.SetItemSlotType(ItemType.Waist);

        Slot feetSlot = Instantiate(_slotPrefab, _feet.transform);
        feetSlot.SetItemSlotType(ItemType.Feet);

        // Spawn Weapon
        Slot slot = Instantiate(_slotPrefab, _weapon.transform);
        slot.CreateItemUI(_item);
    }
}
