using System;

using UnityEngine;

namespace ThirdPersonShooter.UI
{
	public class MainMenu : Menubase
	{
		public override string ID => "main";

		public override void OnOpenMenu(UIManager _manager) => _manager.SetAudioListenerState(true);
		
		public override void OnCloseMenu(UIManager _manager) => _manager.SetAudioListenerState(false);

		public void OnclickPlay() => GameManager.Instance.LevelManager.LoadGame(() => UIManager.ShowMenu("HUD", false));

		public void OnClickOptions() => UIManager.ShowMenu("Options");

		public void OnClickQuit() => GameManager.Instance.QuitGame();
	}
}