using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
		AudioManager.Instance.PlayGGSound();
        GameManager.Instance.LoadNextLevel();
    }
}
