using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IEnumerator Start()
    {
        var services = new ServiceLocator();

        foreach (var service in services.GetServices())
        {
            yield return service.Init();
        }
    }
}