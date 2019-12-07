using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetVisual : MonoBehaviour
{

    [SerializeField] private float winAnimTime;
    [SerializeField] private AnimationCurve winAnimCurve;

    public void Die() {
        gameObject.SetActive(false);
        //Instantiate(GameManager.Instance.dieParticles, transform.position, Quaternion.identity, null);
    }

}
