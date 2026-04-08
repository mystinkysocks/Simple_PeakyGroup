using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        var services = new ServiceLocator();
    }
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        foreach (var service in ServiceLocator.Instance.GetServices())
        {
            yield return service.Init();
        }
    }
}