using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DogPatrol : MonoBehaviour
{
    public Transform dogObject;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        dogObject.position = Vector2.MoveTowards(dogObject.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)dogObject.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
            Vector3 localScale = dogObject.localScale;
            localScale.x *= -1f;
            dogObject.localScale = localScale;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (dogObject != null && startPoint != null &&  endPoint != null)
        {
            Gizmos.DrawLine(dogObject.position, startPoint.position);
            Gizmos.DrawLine (dogObject.position, endPoint.position);
        }
    }
}
