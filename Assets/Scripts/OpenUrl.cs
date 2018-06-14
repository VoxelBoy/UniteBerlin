using UnityEngine;

public class OpenUrl : MonoBehaviour
{

	public string url;

	public void OnButtonClicked()
	{
		Application.OpenURL(url);
	}
}
