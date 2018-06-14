using System.Reflection;
using UnityEngine;

public class OpenAssetStore : MonoBehaviour {

	public void OnButtonClicked()
	{
		#if UNITY_EDITOR
		var type = Assembly.GetAssembly(typeof(UnityEditor.EditorWindow)).GetType("UnityEditor.AssetStoreWindow");
		UnityEditor.EditorWindow.GetWindow(type);
		#endif
	}
}
