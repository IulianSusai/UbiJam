using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowVisual : MonoBehaviour
{
    [SerializeField] private GameObject shadow;
    [SerializeField] private GameObject hightlight;


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
        if (hightlight != null)
        {
            float rot_z = Mathf.Atan2(-transform.position.y, -transform.position.x) * Mathf.Rad2Deg;
            hightlight.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        }
    }
}
