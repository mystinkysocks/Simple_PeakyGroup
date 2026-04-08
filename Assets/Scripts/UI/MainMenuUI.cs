using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button cleanButton;

    private void Start()
    {
        cleanButton.onClick.AddListener(OnClean);
    }

    private void OnClean()
    {
        if(ServiceLocator.Instance.TryGet(out SaveManager saveManager))
        {
            if(ServiceLocator.Instance.TryGet(out GridBuilder gridBuilder))
            {
                saveManager.Clean();
                gridBuilder.RebuildGrid();
            }
        }
    }
}
