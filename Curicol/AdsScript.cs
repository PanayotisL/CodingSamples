using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsScript : MonoBehaviour
{
   //Request an adverstisment to be sent to mobile device
    void Start()
    {
        RequestInterstitialAds();
    }
    //Once game over canvas is activated them show advertisement and the delete it for efficiency
    void Update()
    {
        if (GameScript.isGameOver == true)
        {

                showInterstitialAd();
                RemoveAd();
            
        }

    }
    //Diplay the the advertisement
    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            Debug.Log("Show AD");
        }

    }
    //Setting type of advertisement 
    InterstitialAd interstitial;
    //Requesting the advertisement id to establish what ad will be sent to the device
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-7281262554497856/2387886663";

#if UNITY_ANDROID
        string adUnitId = adID;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize the InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        //Building the production advertisement
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD Loaded");

    }
    //Deleting the advertisement
    private void RemoveAd()
    {
            interstitial.Destroy();
            Debug.Log("Ad Deleted");
    }


}