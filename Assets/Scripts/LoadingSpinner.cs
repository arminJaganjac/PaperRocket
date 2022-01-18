using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSpinner : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(nameof(HideSpinner));
    }

    IEnumerator HideSpinner()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
    }
}
