using UnityEditor;

public class LightingMenuItem {

	[MenuItem("Window/Custom/LightingMenuItem %#l")]
	public static void Show()
	{
		EditorApplication.ExecuteMenuItem("Window/Lighting/Settings");
	}
}
