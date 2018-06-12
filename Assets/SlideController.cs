using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[ExecuteInEditMode]
public class SlideController : MonoBehaviour
{

	public int slideIndex;
	public List<GameObject> slides = new List<GameObject>();

	public int SlideIndex
	{
		get { return slideIndex; }
		set
		{
			if (slides.Count == 0)
			{
				GatherSlidesInScene();
			}

			slideIndex = Mathf.Clamp(value, 0, slides.Count - 1);
			ShowSlideAtIndex(slideIndex);
		}
	}

	private void GatherSlidesInScene()
	{
		slides = new List<GameObject>();
		
		var activeScene = EditorSceneManager.GetActiveScene();
		if (activeScene.IsValid() == false)
		{
			return;
		}

		var rootGOs = activeScene.GetRootGameObjects().ToList();
		slides = rootGOs.FindAll(x => x.name.StartsWith("slide", StringComparison.InvariantCultureIgnoreCase));
		slides.Remove(gameObject);
		slides.Sort((x,y) => x.name.CompareTo(y.name));

		//Make sure Slide Index gets clamped
		SlideIndex = SlideIndex;
	}

	void OnEnable()
	{
		SceneView.onSceneGUIDelegate += OnSceneGUI;
		EditorApplication.hierarchyChanged += OnHierarchyChanged;
		GatherSlidesInScene();
	}

	private void OnHierarchyChanged()
	{
		GatherSlidesInScene();
	}

	void OnDisable()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	private void OnSceneGUI(SceneView sceneview)
	{
		Handles.BeginGUI();
		GUILayout.BeginArea(new Rect(Screen.width - 100f, Screen.height - 60f, 100f, 60f));
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("<<"))
		{
			SlideIndex--;
		}
		if (GUILayout.Button(">>"))
		{
			SlideIndex++;
		}

		if (Event.current.keyCode == KeyCode.LeftArrow && Event.current.type == EventType.KeyDown)
		{
			SlideIndex--;
			Event.current.Use();
		}
		
		if (Event.current.keyCode == KeyCode.RightArrow && Event.current.type == EventType.KeyDown)
		{
			SlideIndex++;
			Event.current.Use();
		}
		
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		Handles.EndGUI();
	}

	private void ShowSlideAtIndex(int index)
	{
		if (index < 0 || index >= slides.Count)
		{
			Debug.LogError("Slide index out of bounds: " + index);
			return;
		}

		for (int i = 0; i < slides.Count; i++)
		{
			slides[i].SetActive(i == index);
		}
	}
}
