using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private PlanetVisual visual;
    [SerializeField] private LineRenderer line;
    [SerializeField] private TrailRenderer trail;
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
        ActionsController.Instance.onTap += OnTap;
		ActionsController.Instance.onHold += OnHold;
        ActionsController.Instance.onEndTap += OnEndTap;
	}

	private void OnDestroy() {
        ActionsController.Instance.onTap -= OnTap;
        ActionsController.Instance.onHold -= OnHold;
        ActionsController.Instance.onEndTap -= OnEndTap;
    }

    void Restart ()
    {
        transform.position = initialPosition;
        rb.velocity = initialVelocity;
    }

    private void OnTap(BlackHole _hole) {
		if (!rb.isKinematic) {
			line.gameObject.SetActive(true);
			line.SetPosition(0, transform.position);
			line.SetPosition(1, _hole.transform.position);
		}
    }

    private void OnHold(BlackHole _hole) {
		if (!rb.isKinematic) {
			Vector3 moveDir = _hole.transform.position - transform.position;
			rb.velocity += new Vector2(moveDir.x, moveDir.y).normalized * GameManager.Instance.planetRepelForce;
			SetLine(_hole.transform.position);
		}
	}

    private void SetLine(Vector3 endPos) {
        Debug.LogError("END POS: " + endPos);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, endPos);
    }

    private void OnEndTap() {
        line.gameObject.SetActive(false);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("BlackHole") || collision.gameObject.CompareTag("Obstacle")) {
            if (restartPositionObHit) {
                Restart();
            } else
            {
                GameManager.Instance.ShakeCamera();
				rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                visual.Die();
                line.gameObject.SetActive(false);
                trail.gameObject.SetActive(false);
				AudioManager.Instance.PlayDieSound();
                Invoke("OnDie", 1f);
            }

		}
	}

    private void OnDie() {
        UIManager.Instance.OpenGameOverPage();
    }

}
