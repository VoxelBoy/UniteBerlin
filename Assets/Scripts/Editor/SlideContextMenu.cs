using System.Linq;
using TMPro;
using UnityEditor;

public class SlideContextMenu
{
    [MenuItem("CONTEXT/Slide/Gather text elements")]
    private static void GatherTextElements(MenuCommand menuCommand)
    {
        var slide = menuCommand.context as Slide;
        slide.Elements = slide.GetComponentsInChildren<TextMeshProUGUI>().ToList().ConvertAll(x => x.gameObject);
    }
}