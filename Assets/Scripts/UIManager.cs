using UnityEngine;

namespace StarterAssets
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryUI;
        [SerializeField] private StarterAssetsInputs _input;

        private void Start()
        {
            _inventoryUI.SetActive(false);
        }

        void Update()
        {
            if(_input.openInventory)
            {
                _inventoryUI.SetActive(true);
            }
            else
            {
                _inventoryUI.SetActive(false);
            }
        }
    }
}
