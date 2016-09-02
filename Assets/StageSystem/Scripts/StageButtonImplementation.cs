/** Originally created by
 *  Damar Inderajati */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DI.StageSystem {
	public class StageButtonImplementation : MonoBehaviour {

		[HideInInspector]
		public string id;
		[HideInInspector]
		public string nextLevelId;

		// Use this for initialization
		void Start () {
			GetComponent<Button>().onClick.AddListener(() => { LoadLevel(id); });
		}
	
		public virtual void LoadLevel(string levelName)
		{
			if (StageManager.isLevelUnlocked(levelName)) {
				PlayerPrefs.SetString("NextLevelId", nextLevelId);
				SceneManager.LoadScene(levelName);
			}
		}
	}

}
