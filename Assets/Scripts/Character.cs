using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Slot _slotPrefab;

    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _shoulders;
    [SerializeField] private GameObject _neck;
    [SerializeField] private GameObject _ring;
    [SerializeField] private GameObject _hands;
    [SerializeField] private GameObject _torso;
    [SerializeField] private GameObject _waist;
    [SerializeField] private GameObject _feet;
    [SerializeField] private GameObject _weapon;

    void Start()
    {
        IterateOverCharacter();
    }

    private void IterateOverCharacter()
    {
        Instantiate(_slotPrefab, _head.transform);
        Instantiate(_slotPrefab, _shoulders.transform);
        Instantiate(_slotPrefab, _neck.transform);
        Instantiate(_slotPrefab, _ring.transform);
        Instantiate(_slotPrefab, _hands.transform);
        Instantiate(_slotPrefab, _torso.transform);
        Instantiate(_slotPrefab, _waist.transform);
        Instantiate(_slotPrefab, _feet.transform);
        Instantiate(_slotPrefab, _weapon.transform);
    }
}
