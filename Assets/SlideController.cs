using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			PlayerPrefs.SetInt("SlideIndex", slideIndex);
			ShowSlideAtIndex(slideIndex);
		}
	}

	private void GatherSlidesInScene()
	{
		slides = new List<GameObject>();

		Scene activeScene;

		if (Application.isPlaying)
		{
			activeScene = SceneManager.GetActiveScene();
		}
		else
		{
			activeScene = EditorSceneManager.GetActiveScene();
		}
		
		if (activeScene.IsValid() == false || activeScene.isLoaded == false)
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
		SlideIndex = PlayerPrefs.GetInt("SlideIndex", slideIndex);
		GatherSlidesInScene();
	}

	private void OnHierarchyChanged()
	{
		GatherSlidesInScene();
	}

	void OnDisable()
	{
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		EditorApplication.hierarchyChanged -= OnHierarchyChanged;
	}

	void OnGUI()
	{
		OnSceneGUI(null);
	}

	private void OnSceneGUI(SceneView sceneview)
	{
		Handles.BeginGUI();
		var buttonheight = sceneview == null ? 20f : 60f;
		GUILayout.BeginArea(new Rect(Screen.width - 100f, Screen.height - buttonheight, 100f, buttonheight));
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

		if ((Event.current.keyCode == KeyCode.Alpha0 || Event.current.keyCode == KeyCode.Keypad0) &&
		    Event.current.type == EventType.KeyDown)
		{
			SlideIndex = 0;
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
