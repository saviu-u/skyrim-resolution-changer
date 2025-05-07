# Skyrim Resolution Changer

An **executable file** that gives one more solution for changing TESV Skyrim's resolution according to your main monitor
resolution

It does it by changing the `.exe` to inject the resolution into the `SkyrimPrefs.ini` file before initializing the game
itself


## Installation ***(If you want to open the game from Steam)***

1. Locate your Skyrim folder (`steamapps\common\Skyrim Special Edition`)
2. Rename the file `SkyrimSELauncher.exe` to `SkyrimSEOriginal.exe`
3. Get `skyrim_resolution_changer.exe` from the [**Github's Releases**](https://github.com/saviu-u/skyrim-resolution-changer/releases) or build it yourself
4. Move it to the game's folder (`steamapps\common\Skyrim Special Edition`)
5. Rename `skyrim_resolution_changer.exe` to `SkyrimSELauncher.exe`
6. You should have:
```
Skyrim Special Edition/
├── ...
├── SkyrimSELauncher.exe ← The new executable ("skyrim_resolution_changer.exe")
├── SkyrimSEOriginal.exe ← The original game executable
└── ...
```

And you are done, you should be able to open Skyrim from the Steam menu


> **If you are using SKSE**
>
> It should be the same logic
> 
> Rename your `skse64_loader.exe` to `SkyrimSEOriginal.exe`,
> 
> This `SkyrimSEOriginal.exe` is just the executable it will call after it's done changing the resolution

## Custom installation ***(For users that don't want to rename their files)***

1. Locate your Skyrim folder (`steamapps\common\Skyrim Special Edition`) and move your `skyrim_resolution_changer.exe` into it.
2. Run `skyrim_resolution_changer.exe`, wait it until it errors out and check the new `skyrim_resolution_changer.ini` file created in the same folder

> **(You can also copy the file from the github repo if you want)**

3. Edit the `ExecutablePath` and rename the `.exe` the way you want

```ini
[Paths]
ExecutablePath="MyAwesomeSkyrimExecutable.exe"
SkyrimPrefsPath="My Games\Skyrim Special Edition\SkyrimPrefs.ini"
```
4. Run the executable manually

Enjoy!

## FAQ

### **Q: Why??**

**A:** Skyrim's Creation Engine is a mess for a lot of reasons, tied framerates, weird bugs and all the other stuff most
modders have already solved, the one caveat for me is the lack of resolution settings inside the game, and it's
understandable, the engine is made to pre-load stuff so it requires the launcher.

My specific problem and the reason to create this project is:
**I am using Moonlight + Sunshine to play PC games** and Skyrim is the pain in my neck

Not only the Launcher was not made
for a controller, but the resolution keeps the same forever, if I am playing on a 4k television, change the
resolution to 4k and then go back to my PC, I have not only to re-change the resolution back, but if I don't, I see
a quarter of my screen due to my 1080p monitor, which is not the experience I wanted.., this `.exe` solves this for me!

### **Q: But there is a `.dll` solution in NexusMods called "Auto Resolution"**

**A:** Yes, but there are 3 different requirements including SKSE, which is fine, if you reached in this repository you
probably use it as well, the thing is I wanted to make an agnostic version which doesn't depend on it,
if you are using NexusMod or SKSE manual plugins already, this repository is only useful if the existing mod didn't
worked for you or you don't want to use SKSE at all.
