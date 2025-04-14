using System;
using System.Collections;
using UnityEngine;

public class TimedFunctionHelper : MonoBehaviour
{
    public static TimedFunctionHelper Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Invoke(Action action, float delay)
    {
        StartCoroutine(InvokeRoutine(action, delay));
    }

    private IEnumerator InvokeRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
