using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisual : MonoBehaviour
{

    [SerializeField] private float winAnimTime;
    [SerializeField] private AnimationCurve winAnimCurve;

    private GameObject shadow;
    private GameObject hightlight;

    private void Awake()
    {
        if (GameManager.Instance.shadowPref != null)
        {
            shadow = Instantiate(GameManager.Instance.shadowPref, Vector3.zero, Quaternion.identity, transform);
            shadow.transform.localScale = Vector3.one;
        }
        if (GameManager.Instance.planetHightlight != null) {
            hightlight = Instantiate(GameManager.Instance.planetHightlight, transform.position, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        SetupShadows();
        RotateHightlight();
    }

    private void SetupShadows()
    {
        if (shadow != null)
        {
            shadow.transform.localPosition = transform.position.normalized * transform.position.magnitude * GameManager.Instance.shadowDistance * 0.01f;
        }
    }

    private void RotateHightlight()
    {
        if (hightlight != null) {
            float rot_z = Mathf.Atan2(-transform.position.y, -transform.position.x) * Mathf.Rad2Deg;
            hightlight.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        }
    }

    public void Die() {
        gameObject.SetActive(false);
        Instantiate(GameManager.Instance.dieParticles, transform.position, Quaternion.identity, transform.parent);
    }

}
