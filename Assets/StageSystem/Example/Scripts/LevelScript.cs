using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DI.StageSystem
{
	public class LevelScript : MonoBehaviour
	{

		public Button unlockBtn, lockBtn;

		// Use this for initialization
		void Start()
		{
			unlockBtn.onClick.AddListener(() => { StageManager.UnlockNextLevel(); });
			lockBtn.onClick.AddListener(() => { StageManager.LockLevel(PlayerPrefs.GetString("NextLevelId")); });
		}
	}
}