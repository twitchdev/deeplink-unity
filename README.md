
# Twitch Unity Deep Link Sample

## What does this do?

This example shows you how to check if Twitch is installed on both Android and iOS in Unity.
Additionally, this showcases how to launch a broadcast for a particular game ID using the Twitch mobile app's deep link functionality.

## How to use it

Depending on which mobile platform and OS version you are targeting, you may need to make additional changes.
See additional details below for a given platform.

### UI interface

The "Open Twitch" button will launch the Twitch mobile app. Buttons will disable if Twitch is not installed.

The input field (i.e. text box) is used to enter your game ID. A game ID can be retrieved via the [Get Games](https://dev.twitch.tv/docs/api/reference#get-games) API endpoint.
Once the game ID has been entered, tap the "Broadcast" button to start Twitch streaming via the deep link functionality.

### Android

On Unity 2021 and above, no changes will be needed.

When using Unity 2020, the following manifest change is required:

    <meta-data android:name="unityplayer.UnityActivity" android:value="true" />

When using Unity 2019 or earlier, the following manifest changes are required. Note this was not tested but should work:

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

You must add "twitch" in `LSApplicationQueriesSchemes` to your app's Info.plist file.

There are two ways to do so:

#### 1. Manually editing the plist

This will require you to export to Xcode. plist example:

    <key>LSApplicationQueriesSchemes</key>
        <array>
            <string>twitch</string>
        </array>

More documentation can be found [here](https://developer.apple.com/documentation/uikit/uiapplication/1622952-canopenurl?language=objc).

#### 2. Programmatically editing the plist

An example can be found [here](https://github.com/Nrjwolf/unity-ios-can-open-url#example).

## Acknowledgments and appendix

Specials thanks to @Nrjwolf for creating [UNITY-IOS-CAN-OPEN](https://github.com/Nrjwolf/unity-ios-can-open-url).
