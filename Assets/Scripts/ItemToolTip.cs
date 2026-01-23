using TMPro;
using UnityEngine;

public class ItemToolTip : MonoBehaviour
{
    public static ItemToolTip Instance;
    [SerializeField] public TMP_Text _titleText;
    [SerializeField] public TMP_Text _descriptionText;
    [SerializeField] private Color _commonColor;
    [SerializeField] private Color _rareColor;
    [SerializeField] private Color _epicColor;
    [SerializeField] private Color _legendaryColor;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Deactivate();
    }

    public void Activate(Item item)
    {
        gameObject.SetActive(true);
        _titleText.text = item._Name;
        _descriptionText.text = item._Description;
        SetTitleColor(item._Rarity);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void SetTitleColor(Rarity rarity)
    {
        switch(rarity)
        {
            case Rarity.Common:
                _titleText.color = _commonColor;
                break;
            case Rarity.Rare:
                _titleText.color = _rareColor;
                break;
            case Rarity.Epic:
                _titleText.color = _epicColor;
                break;
            case Rarity.Legendary:
                _titleText.color = _legendaryColor;
                break;
        }
    }
}
