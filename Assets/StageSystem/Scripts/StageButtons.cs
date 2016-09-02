using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** Originally created by
 *  Damar Inderajati */

using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DI.StageSystem
{
	public class StageButtons : MonoBehaviour
	{
		public StageButton[] buttons;

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
			foreach (string id in StageButtonDrawer.ReadNames())
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
			sceneNames = StageButtonDrawer.ReadNames();
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
					int choosen = 0;
					for (int i = 0; i < sceneNames.Length; i++)
					{
						if (btn.id == sceneNames[i])
						{
							choosen = EditorGUILayout.Popup(i, sceneNames, GUILayout.Width(100));
						}
					}
					btn.id = sceneNames[choosen];

					EditorGUILayout.EndHorizontal();

					btn.setToUnlock = EditorGUILayout.Toggle("Set To Unlock", btn.setToUnlock);

					choosen = 0;
					for (int i = 0; i < sceneNames.Length; i++)
					{
						if (btn.nextLevelId == sceneNames[i])
						{
							choosen = EditorGUILayout.Popup("Next Level ID", i, sceneNames);
						}
					}
					btn.nextLevelId = sceneNames[choosen];

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

	}
#endif
}