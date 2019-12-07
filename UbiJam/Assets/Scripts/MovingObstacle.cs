using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float moveDelay;
    [SerializeField] private float moveTime;
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private GameObject movingObst;
    [SerializeField] private List<GameObject> movePoints;

    private bool isMoving;
    private float startMoveTime;
    private Vector3 startPos;
    private Vector3 endPos;
    private int moveIndex;
    private void Start() {
        moveIndex = 0;
        movingObst.transform.position = movePoints[0].transform.position;
        StartMove();
    }

    private void StartMove() {
        moveIndex++;
        Transform nextMove = movePoints[moveIndex % movePoints.Count].transform;
        isMoving = true;
        startMoveTime = Time.time;
        startPos = movingObst.transform.position;
        endPos = nextMove.position;
    }

    private void UpdateMove() {
        float timeSinceStart = Time.time - startMoveTime;
        float percentage = timeSinceStart / moveTime;
        float curve = moveCurve.Evaluate(percentage);
        movingObst.transform.position = Vector3.Lerp(startPos, endPos, curve);
        if(percentage >= 1.0f) {
            isMoving = false;
            movingObst.transform.position = endPos;
            Invoke("StartMove", moveDelay);
        }
    }

    private void Update() {
        if (isMoving) {
            UpdateMove();
        }
    }


}
