using ThirdPersonShooter.Entities.Player;
using ThirdPersonShooter.UI;

using UnityEngine;

namespace ThirdPersonShooter
{
	[RequireComponent(typeof(LevelManager), typeof(SettingManager))]
	public class GameManager : Singleton<GameManager>
	{
		public LevelManager LevelManager { get; private set; }
		public SettingManager Settings { get; private set; }

		public PlayerEntity Player { get; set; }
		
		public bool IsPaused { get; private set; }

		protected override void Awake()
		{
			base.Awake();

			if(!IsValid())
			{
				CreateSingletonInstance();

				LevelManager = gameObject.GetComponent<LevelManager>();
				Settings = gameObject.GetComponent<SettingManager>();
				LevelManager.LoadUI();
			}
		}

		public void QuitGame()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}

		public void TogglePaused()
		{
			IsPaused = !IsPaused;
			Time.timeScale = IsPaused ? 0 : 1;
			
			if(IsPaused)
				UIManager.ShowMenu("Pause");
			else
			{
				UIManager.HideMenu("Pause");
			}
		}
	}
}