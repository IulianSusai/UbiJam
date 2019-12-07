using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObstacle : MonoBehaviour
{
    [SerializeField] private float scaleTime;
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 endScale;
    [SerializeField] private AnimationCurve scaleCurve;
    [SerializeField] private List<GameObject> scalingObstacles;

    private bool isScaling;
    private float scaleStartTime;

    private void Start() {
        StartScaling();
    }

    private void StartScaling() {
        isScaling = true;
        scaleStartTime = Time.time;
        foreach (GameObject go in scalingObstacles) {
            go.transform.localScale = startScale;
        }
    }

    private void UpdateScale() {
        float timeSinceStrart = Time.time - scaleStartTime;
        float percentage = timeSinceStrart / scaleTime;
        float curve = scaleCurve.Evaluate(percentage);

        foreach(GameObject go in scalingObstacles) {
            go.transform.localScale = Vector3.Lerp(startScale, endScale, curve);
        }

        if(percentage >= 1.0f) {
            isScaling = false;
        }

    }

    private void Update() {
        if (isScaling) {
            UpdateScale();
        }
    }

}
