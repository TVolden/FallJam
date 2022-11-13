using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ObstacleController : NetworkBehaviour
{
    public float horizontal = 0.5f;
    public float vertical = 0.5f;
    public float speed = 1.0f;
    public Vector3 direction = Vector3.up;
    public Transform top;
    public Transform bottom;
    public Transform bottom2;

    // Start is called before the first frame update
    void Start()
    {

    }

    [ServerCallback]
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        var v = top.position - bottom.position;
        var p = Vector3.Project(transform.position - bottom.position, v);
        vertical = p.magnitude / v.magnitude;
    }

    public void MoveToBottom()
    {
        transform.position = horizontal * bottom.position + (1-horizontal) * bottom2.position;
    }
}
