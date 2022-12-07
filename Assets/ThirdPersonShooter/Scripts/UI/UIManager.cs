using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

using UnityEditor;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace ThirdPersonShooter.UI
{
	public class UIManager : Singleton<UIManager>
	{
		public static void ShowMenu(string _id, bool _additive = true) => Instance.ActiveMenu(_id, _additive);

		public static void HideMenu(string _id) => Instance.DeaactivateMenu(_id);
		
		public InputSystemUIInputModule inputModule;

		[SerializeField] private AudioListener audioListener;
		[SerializeField] private AudioSource uisSource;
		[SerializeField] private Menubase[] menus;

		private readonly Dictionary<string, Menubase> menuDictionary = new Dictionary<string, Menubase>();
		private readonly List<string> activeMenus = new List<string>();

		private void Start()
		{
			foreach(Menubase menu in menus)
			{
				if(!menuDictionary.ContainsKey(menu.ID))
				{
					menuDictionary.Add(menu.ID, menu);
					if(menu.IsDefault)
					{
						activeMenus.Add(menu.ID);
						menu.SetVisible(true);
						menu.OnOpenMenu(this);
					}
				}
				else
				{
					Debug.LogError($"Duplicate menu ID detected! id:{menu.ID}");
				}
			}
		}

		public void SetAudioListenerState(bool _active) => audioListener.enabled = _active;

		public void PlaySound(AudioClip _clip) => uisSource.PlayOneShot(_clip);

		private void ActiveMenu(string _id, bool _additive = true)
		{
			if(!_additive)
			{
				while(activeMenus.Count > 0)
				{
					string id = activeMenus[0];
					menuDictionary[id].OnCloseMenu(this);
					menuDictionary[id].SetVisible(false);
					activeMenus.RemoveAt(0);
				}
			}
		}

		private void DeaactivateMenu(string _id)
		{
			if(activeMenus.Contains(_id))
			{
				activeMenus.Remove(_id);
				menuDictionary[_id].OnCloseMenu(this);
				menuDictionary[_id].SetVisible(false);
			}
		}
	}
}