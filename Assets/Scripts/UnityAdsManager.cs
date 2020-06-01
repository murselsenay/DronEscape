using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class UnityAdsManager : MonoBehaviour
{

    GameObject mainMenuObj;
    MainMenu mainMenu;

    private void Awake()
    {
        Advertisement.Initialize("2613000");
    }
    void Start()
    {
        mainMenuObj = GameObject.Find("MainMenuContoller");
        mainMenu = mainMenuObj.GetComponent<MainMenu>();
    }
    // Use this for initialization
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleShowResult });
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                mainMenu.FinishAction();
                break;
            case ShowResult.Skipped:
                Debug.Log("Player did not fully watch the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad");
                break;
        }
    }
}
