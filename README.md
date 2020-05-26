# FlexASIO_ConfigGUI
Simply a Graphical Interface to help in creating the FlexASIO.toml configuration file.

This uses tommy toml. A one file TOML parser. https://github.com/dezhidki/Tommy

This also contains 4 files taken straight from FlexASIO project. (to list devices. Yes i am lazy.) https://github.com/dechamps/FlexASIO

There is a bug when trying to set 0.0 as latency. It is not a Float, and must NOT be saved as string.
So if you want to use 0.0, use a random number as latency, then change it manualy into the file.


![alt text](screenshot_FlexASIO_Config.png)
