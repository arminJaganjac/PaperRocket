using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] bool testMode = true;

    public static AdManager Instance;

    public int lifeCounter = 10;

    public float timePlayingTimer = 300f;

    public static bool isFirstRun = true;

#if UNITY_ANDROID
    string gameId = "4544999";
#elif UNITY_IOS
    string gameId = "4544998";
#endif


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    void Update()
    {
        if (timePlayingTimer > 0)
        {
            timePlayingTimer -= Time.deltaTime;
        }
    }

    public void ShowAd()
    {
        Advertisement.Show("Interstitial_Android");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                // Ad finished
                break;
            case ShowResult.Skipped:
                // Ad was skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }
}