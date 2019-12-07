using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

	private BlackHole holeRef;
	private Vector3 moveDir;
	[SerializeField] private Rigidbody2D rb;
	private float currentDir = 1.0f;
	private float force;

	private void Start() {
		ActionsController.Instance.onTap += OnTap;
		ActionsController.Instance.onHold += OnHold;
		ActionsController.Instance.onEndTap += OnEndTap;
	}

	private void OnDestroy() {
		ActionsController.Instance.onTap -= OnTap;
		ActionsController.Instance.onHold -= OnHold;
		ActionsController.Instance.onEndTap -= OnEndTap;
	}

	private void OnTap(BlackHole _hole) {
		//moveDir = _hole.transform.position - transform.position;
	}

	private void OnHold(BlackHole _hole) {
	 	Vector3 moveDir = _hole.transform.position - transform.position;
		rb.velocity += new Vector2( moveDir.x ,moveDir.y).normalized * GameManager.Instance.planetRepelForce;
	}

	private void OnEndTap() {
		//rb.velocity = Vector2.zero;
	}

	public void InitWithHole(BlackHole _bh) {
		holeRef = _bh;
		moveDir = transform.position - _bh.transform.position;
		currentDir = 1;
		force = GameManager.Instance.planetRepelForce;
	}

	public void ChangeDirection() {
		currentDir *= -1;
		force = currentDir == 1 ? GameManager.Instance.planetRepelForce : GameManager.Instance.planetAttractForce;
	}

	public void FixedUpdate() {
		//Vector2 dir = new Vector2(moveDir.x, moveDir.y);
		//rb.MovePosition(rb.position + dir * currentDir * force * Time.fixedDeltaTime);
	}

}
