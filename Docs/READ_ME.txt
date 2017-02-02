Datenbank

Die Datenbank liegt auf einem privaten Server.
F�r den Zugriff wurden spezielle User mit beschr�nkten Rechten erstellt.
Die Datenbank kann f�r das Testen der Applikation genutzt werden. Alle n�tigen Angaben sind im Code hinterlegt.
Alternativ kann mit dem File DBCookBook.sql eine neue Datenbank auf einem anderen Server oder lokal eingerichtet werden.


Xamarin

Um den Code im Visual Studio ausf�hren zu k�nnen muss Xamarin installiert werden.
https://www.xamarin.com/download

Android Emulator

F�r das Ausf�hren der App wird ein Android Emulator ben�tigt.
Dieses kann hier installiert werden: https://www.visualstudio.com/vs/msft-android-emulator/
F�r das Ausf�hren der Adminkonsole ist dies nicht n�tig.

Evtl. ist eine Installation von Intel� HAXM n�tig.
https://software.intel.com/en-us/android/articles/intel-hardware-accelerated-execution-manager


Wir empfehlen folgende Einstellungen f�r den Emulator: 
Target: Android 7.1.1 - API Level 25
CPU/ABI: Google APIs Intel Atom (x86_64)
Memory Options: RAM 1500 VM Heap 32
Emulation Options: Use Host GPU
