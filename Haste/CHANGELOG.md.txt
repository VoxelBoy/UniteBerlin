v1.8.6
===

- Bug fix for recommendations / removing bundled .asset file.

v1.8.5
===

- PRO Haste Recommendations! Haste now intelligently remembers your recent selections and displays them when you open Haste.
  - This is a big change as it involves serializing parts of Haste's search index and changes how objects are represented in that index. Eventually, it will serialize the whole index so that the index can be persisted across compilation and reopening Unity.
- Haste will now pause script compilation while it's open to prevent it from being destroyed.
- Various tweaks and bug fixes.

v1.8.2
===

- Faster async search! Now slow queries won't stall the whole editor.
- Added new setting for disabling "soft" selection while scrolling through results.
  - This is the best solution to prevent expanding the hierarchy and project views.
- Added support for Home, End, Page Up and Page Down to search results.
- Added context menu item for ignoring assets in Haste (see README).
- Added better interface for ignored paths in Haste's preferences.
- Improvements to search results to filter out unlikely matches.
- Fixed bug with some paths being considered invalid.
- Windows paths should be more consistent.
- Many more tweaks and bug fixes!

v1.7.0
===

- Faster list render performance.
- Faster startup time:
    - Initializing dynamic fonts would sometimes take over 1s the first time you opened Haste. No more!
- New backspace behavior:
    - Pressing backspace will now only delete single characters like normal.
    - Holding backspace for 0.2s will clear the query (this should be familiar from mobile keyboards).
- Indexing now pauses automatically during lightmapping.
- Word boundaries should now include numbers.
- Tweaking search result prioritization.
- Bug fixes.
- New setting to reposition Haste (see Unity Preferences > Haste).
- New opt-in to automatically check for updates to Haste (see Unity Preferences > Haste).
- Style/color/contrast cleanup especially on light theme.

v1.6.1
===

- Fixed: some filenames would cause exceptions.
- Fixed: deleted objects would cause exceptions when accessed.

v1.6.0
===

- Now 20x faster and handles large projects.
- Fixed a bug where sources were not enabled by default.
- Search by asset type using ".cs" or ".material".
- Keyboard shortcut now configurable (see README).
- Unity 5 support!
- PRO Source code is now bundled directly instead of the manual email process.

v1.5.1
===

- Fixing bug when selecting project assets due to Windows paths.

v1.5
===

- Drag and drop support directly in Haste.
- Multi-select search results.
- Adding a few more tips for Haste.
- Fixing fuzzy matching for middle-boundary characters.
- Haste's preferences now displays average usage.
- Removing old blur shader from package.

v1.4
===

- PRO Updated menu items for Unity 4.6.
- PRO Add component menu items now available.
- You can search inactive game objects as well.
- Haste displays tips on things you can do with Haste.
- Game objects are color coded with their active and prefab states, just like the hierarchy.
- Disabled upgrade menu items should now be less annoying and always fall to the bottom of your search results.
- Tighter design shows more results.
- Removed search result groupings since in practice it buried relevant results.
- More robust indexing and filtering.
- Fixed a bug when accessing game objects that have been deleted.
- Fixed a memory leak.
