using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button mapButton;
    [SerializeField] private Button cleanButton;

    private void Start()
    {
        mapButton.onClick.AddListener(OnMap);
        cleanButton.onClick.AddListener(OnClean);
    }
    private void OnMap()
    {
        if(ServiceLocator.Instance.TryGet(out MapManager mapManager))
        {
            mapManager.Show();
        }
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
