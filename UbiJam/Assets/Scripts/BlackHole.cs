using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private float currentSpeed = 1;

    private void Awake()
    {
        currentSpeed = GameManager.Instance.blackHoleSpinSpeed;
    }

    private void OnMouseDown() {
		AudioManager.Instance.PlayBlackHoleSound();
        ActionsController.Instance.SendOnTap(this);
        currentSpeed = GameManager.Instance.blackHoleActiveSpinSpeed;
        if (UIManager.Instance.mainPage.gameObject.activeSelf) {
            UIManager.Instance.OpenInGamePage();
        }
    }

    public void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z + currentSpeed));
    }

    private void OnMouseUp() {
		AudioManager.Instance.StopBlackHoleSound();
		ActionsController.Instance.SendOnEndTap();
        currentSpeed = GameManager.Instance.blackHoleSpinSpeed;
    }

    private void OnMouseDrag() {
        ActionsController.Instance.SendOnHold(this);
    }

}
