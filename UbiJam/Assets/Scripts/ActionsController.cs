using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController
{
    private static ActionsController instance;
    private ActionsController() { }
    public static ActionsController Instance {
        get {
            if(instance == null) {
                instance = new ActionsController();
            }
            return instance;
        }
    }

    public Action<BlackHole> onTap;
    public Action<BlackHole> onHold;
    public Action onEndTap;

    public void SendOnTap(BlackHole _hole) {
        onTap?.Invoke(_hole);
    }

    public void SendOnHold(BlackHole _hole) {
        onHold?.Invoke(_hole);
    }

    public void SendOnEndTap() {
        onEndTap?.Invoke();
    }

}
