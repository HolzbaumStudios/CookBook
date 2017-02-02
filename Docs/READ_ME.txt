Datenbank

Die Datenbank liegt auf einem privaten Server.
Für den Zugriff wurden spezielle User mit beschränkten Rechten erstellt.
Die Datenbank kann für das Testen der Applikation genutzt werden. Alle nötigen Angaben sind im Code hinterlegt.
Alternativ kann mit dem File DBCookBook.sql eine neue Datenbank auf einem anderen Server oder lokal eingerichtet werden.


Xamarin

Um den Code im Visual Studio ausführen zu können muss Xamarin installiert werden.
https://www.xamarin.com/download

Android Emulator

Für das Ausführen der App wird ein Android Emulator benötigt.
Dieses kann hier installiert werden: https://www.visualstudio.com/vs/msft-android-emulator/
Für das Ausführen der Adminkonsole ist dies nicht nötig.

Evtl. ist eine Installation von Intel® HAXM nötig.
https://software.intel.com/en-us/android/articles/intel-hardware-accelerated-execution-manager


Wir empfehlen folgende Einstellungen für den Emulator: 
Target: Android 7.1.1 - API Level 25
CPU/ABI: Google APIs Intel Atom (x86_64)
Memory Options: RAM 1500 VM Heap 32
Emulation Options: Use Host GPU
