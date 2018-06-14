using UnityEngine;
using UnityEditor;

namespace Haste {

  /*
  To modify Haste's keyboard shortcut, use the following special characters:

    % (ctrl on Windows, cmd on OS X),
    # (shift),
    & (alt),
    _ (no key modifiers)

  For example to create a menu with the shortcut alt-g use "Window/Haste &g".

  Note that if the shortcut conflicts with another shortcut, Haste may not open.

  For more details, see the [Unity MenuItem docs](http://docs.unity3d.com/ScriptReference/MenuItem.html).
  */
  public static class HasteShortcut {

    [MenuItem("Window/Haste %k", true)]
    public static bool IsHasteEnabled() {
      return HasteSettings.Enabled;
    }

    [MenuItem("Window/Haste %k")]
    public static void Open() {
      HasteWindow.Open();
    }
  }
}
