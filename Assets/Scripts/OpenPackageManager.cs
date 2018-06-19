using UnityEngine;

public class OpenPackageManager : MonoBehaviour
{
    public void OnButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExecuteMenuItem("Window/Package Manager");
#endif
    }
}