using TMPro;
using UnityEngine;

public class ItemToolTip : MonoBehaviour
{
    public static ItemToolTip Instance;
    [SerializeField] public TMP_Text _titleText;
    [SerializeField] public TMP_Text _descriptionText;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
