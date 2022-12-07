using UnityEngine;

namespace ThirdPersonShooter.UI
{
	public class OptionsMenu : Menubase
	{
		public override string ID => "Options";

		[SerializeField] private VolumeSlider[] sliders;

		public override void OnOpenMenu(UIManager _manager)
		{
			foreach(VolumeSlider volumeSlider in sliders)
			{
				volumeSlider.Active();
			}
		}

		public override void OnCloseMenu(UIManager _manager) => PlayerPrefs.Save();

		public void OnclickBack() => UIManager.HideMenu(ID);
	}
}