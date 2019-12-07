using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private PlanetVisual visual;
	[SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool restartPositionObHit = false;
    [SerializeField] private Vector3 initialVelocity = Vector3.zero; 


    Vector3 initialPosition;


    private void Awake()
    {
        initialPosition = transform.position;
        Restart();
    }

    private void Start() {
		ActionsController.Instance.onHold += OnHold;
	}

	private void OnDestroy() {
		ActionsController.Instance.onHold -= OnHold;
	}

    void Restart ()
    {
        transform.position = initialPosition;
        rb.velocity = initialVelocity;
    }

	private void OnHold(BlackHole _hole) {
	 	Vector3 moveDir = _hole.transform.position - transform.position;
		rb.velocity += new Vector2( moveDir.x ,moveDir.y).normalized * GameManager.Instance.planetRepelForce;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("BlackHole") || collision.gameObject.CompareTag("Obstacle")) {
            if (restartPositionObHit) {
                Restart();
            } else
            {
                GameManager.Instance.ShakeCamera();
                rb.isKinematic = true;
                visual.Die();
                Invoke("OnDie", 1f);
            }

		}
	}

    private void OnDie() {
        GameManager.Instance.LoadLevel();
    }

}
