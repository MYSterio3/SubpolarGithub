using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class watchAdforJoy : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    string gameID = "4492207";
#endif

    public GameObject adButtonforJoy;

    void Start()
    {
        Advertisement.Initialize(gameID);
    }

    void OnEnable()
    {
        Advertisement.AddListener(this);
    }

    void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }

    public void PlayAdforJoy(string c)
    {
        Advertisement.Show(c);
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            coinText.AddCoinsforAd();
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Ad failure");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    }
    public void OnUnityAdsDidError(string message)
    {
    }
    public void OnUnityAdsDidStart(string placementId)
    {
    }
}