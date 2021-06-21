using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepLinkTest : MonoBehaviour
{

    public GameObject TwitchBroadcastGameButton;
    public GameObject OpenTwitchButton;
    public GameObject GameInputField;
    public InputField testInputField;
    private int broadcastGameID = 0;
    // Start is called before the first frame update
    void Start()
    {
        TwitchBroadcastGameButton = GameObject.Find("TwitchDeepLinkButton");
        GameInputField = GameObject.Find("GameIDInputField");
        OpenTwitchButton = GameObject.Find("OpenTwitchButton");


        if (isTwitchInstalled())
        {
            Debug.Log("Twitch App Installed!");
            TwitchBroadcastGameButton.SetActive(true);
            GameInputField.SetActive(true);
            OpenTwitchButton.SetActive(true);
        }
        else
        {
            Debug.Log("Twitch App Not Found!");
            TwitchBroadcastGameButton.SetActive(false);
            GameInputField.SetActive(false);
            OpenTwitchButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isTwitchInstalled()
    {
        bool isInstalled = false;
#if UNITY_ANDROID
            //Bundle ID for the Twitch APP
            string bundleId = "tv.twitch.android.app";
            
            //Nasty C# into java reflection
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");
            AndroidJavaObject launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",bundleId);
                        
            //Launch play store if Twitch is not installed
            if (launchIntent == null)
            {
                Application.OpenURL("market://details?id=" + bundleId);
            }
            else
            {
                isInstalled = true;
            }

            //Garbage clean up as we will never use these objects again
            unityPlayer.Dispose();
            currentActivity.Dispose();
            packageManager.Dispose();
            launchIntent.Dispose();
#endif
#if UNITY_IOS
            var iosAppLink = "twitch://open/";
            //Use plugin to call down into IOS's built in "CanOpenURL" function
            if (IOSCanOpenURL.CheckUrl(iosAppLink))
            {
                isInstalled = true;
            }
            else
            {
                Application.OpenURL("itms-apps://itunes.apple.com/us/app/twitch-live-game-streaming/id460177396");
            }
#endif
        return isInstalled;
    }

    public void GatherText()
    {
        SetGameID(testInputField.text);
    }

    public void OpenTwitch()
    {
        Application.OpenURL("twitch://open/");
    }

    public void SetGameID(string gameID)
    {

        int number;

        bool isParsable = int.TryParse(gameID, out number);

        if (isParsable)
        {
            Debug.Log("Game ID is: " + number);
            broadcastGameID = number;
        }
        else
        {
            Debug.Log("Could not be parsed.");
        }
    }

    public void BroadcastGame()
    {
        Application.OpenURL("twitch://broadcast?game_id=" + broadcastGameID.ToString());
    }
}
