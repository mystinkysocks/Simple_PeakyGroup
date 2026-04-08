using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        var services = new ServiceLocator();
        services.Register(new SaveManager());
    }
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        foreach (var service in ServiceLocator.Instance.GetServices())
        {
            yield return service.Init();
        }
    }
    private void OnApplicationQuit()
    {
        if(ServiceLocator.Instance.TryGet(out SaveManager saveManager))
        {
            saveManager.Save();
        }
    }
}