using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private void OnMouseDown() {
        ActionsController.Instance.SendOnTap(this);
    }

    private void OnMouseUp() {
        ActionsController.Instance.SendOnEndTap();
    }

    private void OnMouseDrag() {
        ActionsController.Instance.SendOnHold(this);
    }

}
