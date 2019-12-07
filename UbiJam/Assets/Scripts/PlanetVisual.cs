using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisual : MonoBehaviour
{

    [SerializeField] private float winAnimTime;
    [SerializeField] private AnimationCurve winAnimCurve;

    private GameObject shadow;

    private void Awake()
    {
        if (GameManager.Instance.shadowPref != null)
        {
            shadow = Instantiate(GameManager.Instance.shadowPref, Vector3.zero, Quaternion.identity, transform);
            shadow.transform.localScale = Vector3.one;
        }
    }

    private void Update()
    {
        if (shadow != null) {
            shadow.transform.localPosition = transform.position.normalized * transform.position.magnitude * GameManager.Instance.shadowDistance * 0.01f;
        }
    }

    public void Die() {
        gameObject.SetActive(false);
        //Instantiate(GameManager.Instance.dieParticles, transform.position, Quaternion.identity, null);
    }

}
