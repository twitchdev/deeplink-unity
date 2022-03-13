
# Twitch Unity Deeplink Sample

## What does this do

This example shows you how to check if twitch is installed on both Android and IOS in Unity.
Additionaly, this showcases how to launch a broadcast for a particular game id using the Twitch mobile app's deeplink functionality

## How to use

Depending on which mobile platform and OS version you are targeting you may need to make additional changes.
See below for additional details for a given platform.

### UI interface

The open twitch button will simply launch the twitch app. (Buttons will disable if Twitch is not installed)

The input text box is used to enter your game id. Getting the game id can be done via this api: https://dev.twitch.tv/docs/api/reference#get-games
Once the game id has been entered push the "Broadcast" button to start twitch streaming via the deeplink functionality.

### Android

On Unity 2021 and above no changes will be needed.

When using Unity 2020 it will require the following manifest change:

`<meta-data android:name="unityplayer.UnityActivity" android:value="true" />`

When using Unity 2019 or earlier the following manifest changes will be required. 
(Note this was not tested but should work):

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

There are two ways to do so:
1. Manually via editing the plist, this will require you to export to xcode

plist example:

    <key>LSApplicationQueriesSchemes</key>
        <array>
            <string>twitch</string>
        </array>

More documentation can be found here: https://developer.apple.com/documentation/uikit/uiapplication/1622952-canopenurl?language=objc

2. Alternatively you can do this programatically. Find an example here: https://github.com/Nrjwolf/unity-ios-can-open-url#example

## Acknowledgments and Appendix

Specials thanks to Nrjwolf for creating UNITY-IOS-CAN-OPEN: https://github.com/Nrjwolf/unity-ios-can-open-url
