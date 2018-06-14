using UnityEngine;
using UnityEngine.UI;

public class MethodologySlideController : MonoBehaviour
{

	public Toggle whatToggle;
	public Toggle howToggle;

	public GameObject whatToggleOnContent;
	public GameObject bothTogglesOnContent;
	public GameObject bothTogglesOffContent;

	public void ToggleChecked(bool isOn)
	{
		whatToggleOnContent.SetActive(false);
		bothTogglesOnContent.SetActive(false);
		bothTogglesOffContent.SetActive(false);
		
		if (whatToggle.isOn && howToggle.isOn == false)
		{
			whatToggleOnContent.SetActive(true);
		}
		else if (whatToggle.isOn && howToggle.isOn)
		{
			bothTogglesOnContent.SetActive(true);
		}
		else if (whatToggle.isOn == false && howToggle.isOn == false)
		{
			bothTogglesOffContent.SetActive(true);
		}
	}
}
