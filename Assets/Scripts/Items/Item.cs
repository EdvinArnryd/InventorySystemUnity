using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] string _description;
    [SerializeField] Rarity _rarity;
    [SerializeField] int _size;
    [SerializeField] Sprite _sprite;
    [SerializeField] int _damage;
}
