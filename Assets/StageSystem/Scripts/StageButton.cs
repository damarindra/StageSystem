/** Originally created by
 *  Damar Inderajati */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DI.StageSystem
{
	[System.Serializable]
	public class StageButton
	{
		public Button button;
		public string id;
		public bool setToUnlock = false;
		public bool apply = false;
		public string nextLevelId;
	}
	/*
#if UNITY_EDITOR
	//[CustomPropertyDrawer(typeof(StageButton))]
	public class StageButtonDrawer : PropertyDrawer
	{
		List<string> sceneNames = new List<string>();

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (sceneNames == null || sceneNames.Count == 0)
				sceneNames = ReadNames().ToList();

			EditorGUI.BeginProperty(position, label, property);

			//position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			Rect buttonRect = new Rect(position.x, position.y, position.width, position.height / 4.5f);
			Rect idRect = new Rect(position.x, position.y + position.height / 4.5f, position.width, position.height / 4.5f);
			Rect setToUnlockRect = new Rect(position.x, position.y + (position.height / 4.5f) * 2, position.width, position.height / 4.5f);
			Rect applyRect = new Rect(position.x, position.y + (position.height / 4.5f) * 3, position.width, position.height / 4.5f);
			EditorGUI.PropertyField(buttonRect, property.FindPropertyRelative("button"));
			int choosen = 0;
			for (int i = 0; i < sceneNames.Count; i++)
			{
				if (property.FindPropertyRelative("id").stringValue == sceneNames[i])
				{
					choosen = EditorGUI.Popup(idRect, "ID", i, sceneNames.ToArray());
				}
			}
			property.FindPropertyRelative("id").stringValue = sceneNames[choosen];
			EditorGUI.PropertyField(setToUnlockRect, property.FindPropertyRelative("setToUnlock"));
			EditorGUI.PropertyField(applyRect, property.FindPropertyRelative("apply"));
			if (property.FindPropertyRelative("button").objectReferenceValue != null)
			{
				GameObject btn = property.FindPropertyRelative("button").objectReferenceValue as GameObject;
				if (property.FindPropertyRelative("apply").boolValue && !btn.GetComponent<StageButtonImplementation>())
					btn.AddComponent<StageButtonImplementation>();
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUIUtility.singleLineHeight * 4.5f;
		}

		
	}

#endif*/
}