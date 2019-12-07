using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPage : UIPage
{
    public override void Open() {
        base.Open();
    }

    public override void ClosePage() {
        base.ClosePage();
    }

    public void OnRestartButton() {
        UIManager.Instance.OpenInGamePage();
        GameManager.Instance.LoadLevel();
    }
}
