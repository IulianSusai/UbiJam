using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    private void Update() {
       
        if (Input.GetMouseButtonDown(0)) {
            //ActionsController.Instance.SendOnTap();
        }
        if (Input.GetMouseButton(0)) {
            //ActionsController.Instance.SendOnHold();
        }
        if (Input.GetMouseButtonUp(0)) {
            ActionsController.Instance.SendOnEndTap();
        }
    }
}
