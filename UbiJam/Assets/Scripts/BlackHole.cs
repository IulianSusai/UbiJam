using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private void OnMouseDown() {
		AudioManager.Instance.PlayBlackHoleSound();
        ActionsController.Instance.SendOnTap(this);
    }

    private void OnMouseUp() {
		AudioManager.Instance.StopBlackHoleSound();
		ActionsController.Instance.SendOnEndTap();
    }

    private void OnMouseDrag() {
        ActionsController.Instance.SendOnHold(this);
    }

}
