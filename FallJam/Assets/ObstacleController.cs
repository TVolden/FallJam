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
    public ObstaclePlacer placer;

    // Start is called before the first frame update
    void Start()
    {
        placer = FindObjectOfType<ObstaclePlacer>();
    }

    [ServerCallback]
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        vertical = placer.GetVertical(transform.position);
    }

    public void MoveToBottom()
    {
        transform.position = placer.GetPosition(horizontal, 0.0f);
    }
}
