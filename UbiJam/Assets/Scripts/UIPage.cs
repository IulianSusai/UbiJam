using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPage : MonoBehaviour
{
    public virtual void Open() {
        gameObject.SetActive(true);
    }
    public virtual void ClosePage() {
        gameObject.SetActive(false);
    }
}
