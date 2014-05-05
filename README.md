ForkKnightGame
==============

5/05/2014
-----------------------------
An android version of the project has been created. It should work on most current android devices (tablets, phones, etc).

To run the Android Version of the project you will need to have the following:

An Android Device (Version 2.2 or Higher),
Android APK,
Windows OS (optional, but this guide is for windows),
and USB connection from the device to the Operating System.

A tutorial to download and work with the Android APK is as follows:

1. The download links are as follows: http://code.google.com/android/intro/installing.html
2. http://dl.google.com/android/android_usb_windows.zip
3. You need to modify your Android’s settings to allow the installation of applications from other sources. Under “Settings,” select “Application Settings” and then enable “Unknown Sources.” Also under “Settings,” select “SD Card” and “Phone Storage,” and finally enable “Disable Use for USB Storage”
4. This last step is easy. Open Command Prompt and type the following: adb install <1>/<2>.apk
5. However, when you type the command, replace <1> with the path to your APK file and replace <2> with the name of the APK file. (In this case "AndroidTest.apk")
6. You’re done! Your application is now ready for your use and enjoyment.

USER DOCUMENTATION:

This is the Android Version of the "Fork Knight Game" that was developed by a group of college students for their software engineering practicum.

The game can be started by tapping the "Play" button at the bottom of the landing screen. Hitting the "Quit" button will end the process and return the user to their android device's screen."Perry", the main character, can move around by holding one of the arrow keys down found on either side of the screen. Perry can attack by double tapping the screen. It should be noted that perry cannot move and attack at the same time (That would take years of training :-p) so you should adjust your strategy accordingly.

The goal of the game is the same as the Web version, survive for as long as possible and obtain the highest score. For the mobile version jumping has been disabled and there is no "Replay Button" implemented. To start a 'new' game, the user will have to exit the game manually by touching the 'home' key on their android device and also end the 'Active Application'. This is a barbaric way to end the mobile version but there will (hopefully) be a more robust option in the future.

Thanks!
