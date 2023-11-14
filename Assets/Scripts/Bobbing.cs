using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 1f;

    private float startX;
    private float startY;
    private float startZ;
    private void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
    }
    private void Update()
    {
        transform.position = new Vector3(startX, startY + amplitude * Mathf.Sin(speed * Time.time), startZ);
    }
}
