/** Originally created by
 *  Damar Inderajati */

using UnityEngine;
using System.Collections;

namespace DI.StageSystem
{
	public class StageManager : MonoBehaviour
	{

		public static void UnlockLevel(StageButton sButton)
		{
			PlayerPrefs.SetInt(sButton.id + "isUnlocked", 1);
		}
		public static void UnlockLevel(string id)
		{
			PlayerPrefs.SetInt(id + "isUnlocked", 1);
		}
		public static void LockLevel(StageButton sButton)
		{
			PlayerPrefs.SetInt(sButton.id + "isUnlocked", 0);
		}
		public static void LockLevel(string id)
		{
			PlayerPrefs.SetInt(id + "isUnlocked", 0);
		}
		public static bool isLevelUnlocked(StageButton sButton)
		{
			return PlayerPrefs.GetInt(sButton.id + "isUnlocked", 0) == 1;
		}
		public static bool isLevelUnlocked(string id)
		{
			return PlayerPrefs.GetInt(id + "isUnlocked", 0) == 1;
		}
		public static void UnlockNextLevel()
		{
			PlayerPrefs.SetInt(PlayerPrefs.GetString("NextLevelId") + "isUnlocked", 1);
		}
	}
}