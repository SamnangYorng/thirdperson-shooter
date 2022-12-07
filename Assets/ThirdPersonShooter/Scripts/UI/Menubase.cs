using UnityEngine;

namespace ThirdPersonShooter.UI
{
	public abstract class Menubase : MonoBehaviour
	{
		public bool IsDefault => IsDefault;
		public bool IsVisible => gameObject.activeSelf;
		
		public abstract string ID { get; }

		[SerializeField] private bool isDefault;

		public void SetVisible(bool _visible) => gameObject.SetActive(_visible);

		public virtual void OnOpenMenu(UIManager _mananger) { }
		public virtual void OnCloseMenu(UIManager _mananger) { }
	}
}