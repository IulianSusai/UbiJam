using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlackHole : MonoBehaviour
{
    public List<Rigidbody2D> objectsInRange = new List<Rigidbody2D>();
    public float attractionForce = 1;

    public bool attractAllTheTime = false;

    [Header("Range")]
    public bool useRange = false;
    public float range = 3;

    public void Update()
    {
        if (attractAllTheTime) {
            Attract();
        }
    }

    private void Attract()
    {
        foreach (Rigidbody2D rb in objectsInRange)
        {
            float distance = Vector2.Distance(rb.transform.position, transform.position);

            if (!useRange || distance <= range)
            {
                Vector3 direction = transform.position - rb.transform.position;
                float actualAttraction = (attractionForce / (distance*20)) * 0.1f;
                rb.velocity += new Vector2(direction.x, direction.y) * actualAttraction;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (!attractAllTheTime) {
            Attract();
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(pos.x, pos.y, 0);
    }
}