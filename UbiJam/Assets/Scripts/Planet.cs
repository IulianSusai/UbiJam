using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;

	private void Start() {
		ActionsController.Instance.onHold += OnHold;
	}

	private void OnDestroy() {
		ActionsController.Instance.onHold -= OnHold;
	}

	private void OnHold(BlackHole _hole) {
	 	Vector3 moveDir = _hole.transform.position - transform.position;
		rb.velocity += new Vector2( moveDir.x ,moveDir.y).normalized * GameManager.Instance.planetRepelForce;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("BlackHole") || collision.gameObject.CompareTag("Obstacle")) {
			GameManager.Instance.LoadLevel();
		}
	}

}
