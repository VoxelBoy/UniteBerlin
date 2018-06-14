Haste
===

[Support](http://support.barkingmousestudio.com)

Haste is a quick launcher for Unity. Navigate your project with speed: select GameObjects in your scene, files and folders in your project or execute MenuItems. MenuItem support is only available in the paid version of Haste.

Quick Reference
---

Action | Keyboard | Mouse
---|---|---
Open Haste | ⌘ + K (Ctrl + K on Windows) | Click "Window/Haste"
Navigate Search Results | ↑ or ↓ | Click search result
Select Highlighted Result | Enter | Double-click search result
Go to beginning | Fn + ← (Home on Windows) |
Go to end | Fn + → (End on Windows) |
Go up a page | Fn + ↑ (Page Up on Windows) |
Go down a page | Fn + ↓ (Page Down on Windows) |
Multi-Select Highlighted Result | ⌘ + Enter (Ctrl + Enter on Windows) | ⌘ + Click (Ctrl + Click on Windows)
Dismiss Haste | ESC | Click anywhere outside of Haste

Configuring Haste
---

To modify Haste's keyboard shortcut open the file "Assets/Haste/Editor/InternalResources/HasteShortcut.cs" in your favorite text editor. Then modify _both_ `MenuItem` attributes using the following special characters:

  - `%` (ctrl on Windows, cmd on OS X),
  - `#` (shift),
  - `&` (alt),
  - `_` (no key modifiers)

For example to create a menu with the shortcut alt-g use "Window/Haste &g".

Note that if the shortcut conflicts with another shortcut, Haste may not open.

For more details, see the [Unity MenuItem docs](http://docs.unity3d.com/ScriptReference/MenuItem.html).

(Additional settings are available in the "Haste" tab of "Unity Preferences".)

Searching By File Type
---

With Haste you can also find assets by their type simply by searching for their extension. A few examples:

- `.cs` for C# scripts
- `.unity` for scenes
- `.mat` for materials

Step-By-Step Tutorial
---

##### Step 1. Import Haste into your project.

##### Step 2. Open the included tutorial scene @ `Assets/Haste/Tutorial/Tutorial.unity`

##### Step 3. Press Command+K (⌘+K) on OS X (Ctrl+K on Windows) to open Haste.

This is Haste. You can open it at any time.

The first time you open Haste it will begin indexing your scene hierarchy and project files automatically, making new items available for search as their discovered.

##### Step 4. Type `MyFirstGameObject` into the search box.

Haste will begin listing your search results immediately. Note that searches in Haste are not case-sensitive.

##### Step 5. You can use the up (↑) / down (↓) arrows to navigate the search results. Use the arrows to highlight the GameObject named "first".

##### Step 6. Press Enter (↵) to select the highlighted GameObject.

Pressing enter will select the highlighted result.

Searching by the full name can be tedious. To search faster you can search using Haste's "fuzzy" matching.

##### Step 7. Open Haste and type `msgo`.

Note how Haste highlights the capital letters in the GameObject's name. Haste can search on any "word boundary" which are capital letters or characters that occur after spaces and other characters such as hyphens and parenthesis. Think of this like "keyboard-shortcuts on steroids" where everything in Unity gets an acronym to lookup the object by.

##### Step 8. Press ESC to dismiss Haste.

You can do this at any time when Haste is open without performing any actions.

Next lets use some MenuItem actions... (requires Haste Pro.)

##### Step 9. Open Haste and search for `TutorialPrefab` (or `tutp` or even `tp`).

This brings up the `TutorialPrefab.prefab` in the project's assets.

##### Step 10. Press Enter (↵) to select the prefab.

##### Step 11. Now search for `Instantiate Prefab` (or `ip`) in Haste and press Enter (↵).

Haste Pro provides access to as many built-in MenuItems as possible with Unity's exposed APIs. Haste Pro also indexes custom MenuItems from other editor extensions making it easy to extend Haste's capabilities.

Ignoring Assets
---

You can ignore assets in your project like third-party tools, etc. by right-clicking on the asset and selecting `Haste > Ignore`. The asset can be unignored by right-clicking and selecting `Haste > Unignored`. You can further manage ignored assets in Haste's Preferences inside of the main Unity Preferences.

Missing Menu Items
---

Due to limitations in the current Unity editor APIs the following menu items are not available through Haste:

  - File/New Project...
  - File/Open Project...
  - Edit/Project Settings/Input
  - Edit/Project Settings/Audio
  - Edit/Project Settings/Time
  - Edit/Project Settings/Graphics
  - Edit/Project Settings/Network
