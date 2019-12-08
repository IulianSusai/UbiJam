using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : UIPage
{

	public override void Open() {
		base.Open();
	}

	public override void ClosePage() {
		base.ClosePage();
	}

	public void OnStartButton() {
		AudioManager.Instance.PlayTapSound();
		UIManager.Instance.OpenInGamePage();
		// GameManager.Instance.LoadNextLevel();
	}
}
