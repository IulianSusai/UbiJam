using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public static UIManager Instance { private set; get; }
	public UIPage mainPage;
	public UIPage ingamePage;
	public UIPage gameOverPage;

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void OpenMainPage() {
		ingamePage.ClosePage();
		gameOverPage.ClosePage();
		mainPage.Open();
	}

	public void OpenInGamePage() {
		gameOverPage.ClosePage();
		mainPage.ClosePage();
		ingamePage.Open();
	}

	public void OpenGameOverPage() {
		ingamePage.ClosePage();
		mainPage.ClosePage();
		gameOverPage.Open();
	}

}
