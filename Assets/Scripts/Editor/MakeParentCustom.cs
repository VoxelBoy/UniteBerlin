using System.Linq;
using UnityEngine;
using UnityEditor;

public class MakeParentCustom {

    [MenuItem("Window/Custom/Make Parent %#&p")]
    public static void Show()
    {
        var selection = Selection.GetFiltered<GameObject>(SelectionMode.Editable | SelectionMode.TopLevel).ToList();
        if (selection.Count == 0)
        {
            return;
        }

        var position = Vector3.zero;
        selection.ForEach(x => position += x.transform.position);
        position /= selection.Count;

        var parent = new GameObject("parent");
        Undo.RegisterCreatedObjectUndo (parent, "Created parent");
        
        parent.transform.position = position;
        selection.ForEach(x => Undo.SetTransformParent(x.transform, parent.transform, "Set new parent"));
    }
}
