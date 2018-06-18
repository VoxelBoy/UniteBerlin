using System.Collections.Generic;
using System.Linq;
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

			var lastSlideIndex = slideIndex;
			slideIndex = Mathf.Clamp(value, 0, slides.Count - 1);
			PlayerPrefs.SetInt("SlideIndex", slideIndex);
			ShowSlideAtIndex(slideIndex, slideIndex != lastSlideIndex);
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
			#if UNITY_EDITOR
			activeScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
			#endif
		}
		
		if (activeScene.IsValid() == false || activeScene.isLoaded == false)
		{
			return;
		}

		var rootGOs = activeScene.GetRootGameObjects().ToList();
		int i;
		slides = rootGOs.FindAll(x => int.TryParse(x.name, out i));
		slides.Remove(gameObject);
		slides.Sort((x, y) => int.Parse(x.name).CompareTo(int.Parse(y.name)));
		
		//Make sure there are no gaps in the slide numbers
		int index = 1;
		for (i = 0; i < slides.Count; i++)
		{
			int slideNameInt = int.Parse(slides[i].name);
			if (slideNameInt != index)
			{
				slides[i].name = index.ToString();
			}

			index++;
		}

		//Make sure Slide Index gets clamped
		SlideIndex = SlideIndex;
	}

	void OnEnable()
	{
		#if UNITY_EDITOR
//		Debug.Log("OnEnable, isPlaying:" + Application.isPlayer);
		if (Application.isPlaying == false)
		{
			UnityEditor.SceneView.onSceneGUIDelegate += OnSceneGUI;
			UnityEditor.EditorApplication.hierarchyChanged += OnHierarchyChanged;
		}
		#endif
		SlideIndex = PlayerPrefs.GetInt("SlideIndex", slideIndex);
		GatherSlidesInScene();
	}

	private void OnHierarchyChanged()
	{
		GatherSlidesInScene();
	}

	void OnDisable()
	{
		#if UNITY_EDITOR
		if (Application.isPlaying == false)
		{
			UnityEditor.SceneView.onSceneGUIDelegate -= OnSceneGUI;
			UnityEditor.EditorApplication.hierarchyChanged -= OnHierarchyChanged;
		}
		#endif
	}

	void OnGUI()
	{
		DrawGUI(false);
	}

	private void DrawGUI(bool inSceneView)
	{
		#if UNITY_EDITOR
		UnityEditor.Handles.BeginGUI();
		#endif
		var buttonheight = inSceneView ? 20f : 20f;
		GUI.color = new Color(1f,1f,1f,0.1f);
		//GUILayout.BeginArea(new Rect(Screen.width - 100f, Screen.height - buttonheight, 100f, buttonheight));
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("<<", GUILayout.Width(30f)))
		{
			SlideIndex--;
		}
		if (GUILayout.Button(">>", GUILayout.Width(30f)))
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
		//GUILayout.EndArea();
		#if UNITY_EDITOR
		UnityEditor.Handles.EndGUI();
		#endif
	}

	#if UNITY_EDITOR
	private void OnSceneGUI(UnityEditor.SceneView sceneview)
	{
		DrawGUI(true);
	}
	#endif

	private void ShowSlideAtIndex(int index, bool indexChanged)
	{
		if (index < 0 || index >= slides.Count)
		{
			Debug.LogError("Slide index out of bounds: " + index);
			return;
		}

		for (int i = 0; i < slides.Count; i++)
		{
			slides[i].SetActive(i == index);
			#if UNITY_EDITOR
			if (i == index && indexChanged)
			{
				UnityEditor.Selection.activeGameObject = slides[i];
			}
			#endif
		}
	}
}
