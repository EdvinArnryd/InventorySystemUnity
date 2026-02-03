using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Rarity _rarity;
    [SerializeField] private int _size;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _damage;
    [SerializeField] private ItemType _itemType;

    public string _Name => _name;
    public string _Description => _description;
    public Rarity _Rarity => _rarity;
    public int _Size => _size;
    public Sprite _Sprite => _sprite;
    public int _Damage => _damage;
    public ItemType _ItemType => _itemType;
}
