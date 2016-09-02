using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** Originally created by
 *  Damar Inderajati */

using UnityEngine.SceneManagement;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DI.StageSystem
{
	public class StageButtons : MonoBehaviour
	{
		public StageButton[] buttons = new StageButton[0];

		// Use this for initialization
		void Start()
		{
			for (int i = 0; i < buttons.Length; i++)
			{
				if (buttons[i].setToUnlock)
					StageManager.UnlockLevel(buttons[i]);
				if (StageManager.isLevelUnlocked(buttons[i]))
					buttons[i].button.interactable = true;
				else
					buttons[i].button.interactable = false;
				//buttons[i].button.onClick.AddListener(() => { LoadLevel(buttons[i]); });
			}
		}

		void Update()
		{
			if (!StageManager.isLevelUnlocked(buttons[0]))
				buttons[0].button.interactable = false;
		}


#if UNITY_EDITOR
		[MenuItem("Window/StageSystem/Reset")]
		static void Reset()
		{
			List<string> temp = new List<string>();
			foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
			{
				if (S.enabled)
				{
					string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
					name = name.Substring(0, name.Length - 6);
					temp.Add(name);
				}
			}
			foreach (string id in temp)
			{
				PlayerPrefs.DeleteKey(id + "isUnlocked");
			}
		}
#endif

	}

#if UNITY_EDITOR
	[CustomEditor(typeof(StageButtons))]
	public class StageButtonEditor : Editor
	{
		StageButtons sb;
		string[] sceneNames;

		void OnEnable()
		{
			sb = (StageButtons)target;
			sceneNames = ReadNames();
		}

		public override void OnInspectorGUI()
		{

			EditorGUI.BeginChangeCheck();
			serializedObject.Update();

			EditorPrefs.SetBool("Button Fold", EditorGUILayout.Foldout(EditorPrefs.GetBool("Button Fold", false), "Buttons"));
			if (EditorPrefs.GetBool("Button Fold", false))
			{
				EditorGUI.indentLevel += 1;
				serializedObject.FindProperty("buttons").arraySize = EditorGUILayout.IntField("Size", serializedObject.FindProperty("buttons").arraySize);
				foreach (StageButton btn in sb.buttons)
				{
					EditorGUILayout.Space();
					EditorGUILayout.BeginHorizontal();
					btn.button = EditorGUILayout.ObjectField("Button", btn.button, typeof(Button), true) as Button;

					if (!btn.button)
						GUI.enabled = false;

					btn.id = sceneNames[EditorGUILayout.Popup(FindIndexScene(btn.id, sceneNames.Length-1), sceneNames, GUILayout.Width(100))];

					EditorGUILayout.EndHorizontal();

					btn.setToUnlock = EditorGUILayout.Toggle("Set To Unlock", btn.setToUnlock);
					btn.nextLevelId = sceneNames[EditorGUILayout.Popup("Next Level ID", FindIndexScene(btn.nextLevelId, sceneNames.Length - 1), sceneNames)];

					if (GUILayout.Button(btn.apply ? "Remove" : "Apply"))
					{
						btn.apply = !btn.apply;
						if (btn.apply && !btn.button.gameObject.GetComponent<StageButtonImplementation>())
						{
							StageButtonImplementation sbi = btn.button.gameObject.AddComponent<StageButtonImplementation>();
							sbi.id = btn.id;
							sbi.nextLevelId = btn.nextLevelId;
						}
						else if (!btn.apply && btn.button.gameObject.GetComponent<StageButtonImplementation>())
							DestroyImmediate(btn.button.gameObject.GetComponent<StageButtonImplementation>());
					}
					GUI.enabled = true;

				}
			}
			EditorGUI.indentLevel -= 1;


			if (EditorGUI.EndChangeCheck())
				serializedObject.ApplyModifiedProperties();

		}

		public int FindIndexScene(string id)
		{
			if (id == "")
				return sceneNames.Length - 1;
			int i = 0;
			foreach (string str in sceneNames)
			{
				if (str.Equals(id))
					return i;
				i += 1;
			}
			Debug.Log("ID Scene not found : " + id + ", returning -1");
			return -1;
		}
		public int FindIndexScene(string id, int defaultNumb)
		{
			if (id == "")
				return sceneNames.Length - 1;
			int i = 0;
			foreach (string str in sceneNames)
			{
				if (str.Equals(id))
					return i;
				i += 1;
			}
			Debug.Log("ID Scene not found : " + id + ", returning " + defaultNumb.ToString());
			return defaultNumb;
		}
		string[] ReadNames()
		{
			List<string> temp = new List<string>();
			foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
			{
				if (S.enabled)
				{
					string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
					name = name.Substring(0, name.Length - 6);
					temp.Add(name);
				}
			}
			temp.Add("");
			return temp.ToArray();
		}
	}
#endif
}