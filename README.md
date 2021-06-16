
# Twitch Unity Deeplink Sample

## What does this do

This is an example which shows you how to check if twitch is installed on both Android and IOS in Unity
And how to launch a broadcast for a particular game id using the Twitch app's deeplink functionality

## How to use

Depending on which mobile platform and os version you are targeting you may need to make additional changes.
See below for additional details for a given platform.

### UI interface

The open twitch button will simply launch the twitch app. (Buttons will disable if Twitch is not installed)

The input text box is used to enter your game id. Getting the game id can be done via this api: https://dev.twitch.tv/docs/api/reference#get-games
Once the game id has been entered push the "Broadcast" button to start twitch streaming via the deeplink functionality.

### Android

On Unity 2021 nothing further is required for this to function

Unity 2020 will require this manifest change:

`<meta-data android:name="unityplayer.UnityActivity" android:value="true" />`

Unity 2019 and older will require these manifest changes (Note this was not tested but should work):

    <activity android:name="com.unity3d.player.UnityPlayerNativeActivity"
              android:label="@string/app_name">
      <intent-filter>
        <action android:name="android.intent.action.MAIN" />
        <category android:name="android.intent.category.LAUNCHER" />
        <category android:name="android.intent.category.LEANBACK_LAUNCHER" />
      </intent-filter>
      <meta-data android:name="unityplayer.UnityActivity" android:value="true"
      />
      <meta-data
     android:name="unityplayer.ForwardNativeEventsToDalvik"android:value="false"
      />
    </activity> 

### IOS

You must add twitch in LSApplicationQueriesSchemes to your app's Info.plist

To do this you must export to XCODE to manually edit the plist or alternatively do it programatically
An example of how to do this programtically can be found in Nrjwolf's documentation (Link below)
plist example:

    <key>LSApplicationQueriesSchemes</key>
        <array>
            <string>twitch</string>
        </array>

More documentation can be found here: https://developer.apple.com/documentation/uikit/uiapplication/1622952-canopenurl?language=objc


## Acknowledgments and Appendix

Specials thanks to Nrjwolf for creating UNITY-IOS-CAN-OPEN located here: https://github.com/Nrjwolf/unity-ios-can-open-url
