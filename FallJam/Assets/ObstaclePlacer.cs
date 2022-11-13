using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ObstaclePlacer : NetworkBehaviour
{
    public Vector2 speedRange = new Vector2(0.25f, 0.75f);
    public Transform root;
    public Transform topLeft;
    public Transform bottomLeft;
    public Transform topRight;
    public Transform bottomRight;
    public ObstacleController ObstacleController;

    // Start is called before the first frame update
    [ServerCallback]
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            ObstacleController obstacle = Instantiate(ObstacleController);
            obstacle.speed = Random.Range(speedRange.x, speedRange.y);
            obstacle.placer = this;
            obstacle.transform.parent = root;
            obstacle.vertical = 0;
            obstacle.horizontal = Random.Range(0.1f, 0.9f);
            obstacle.MoveToBottom();
            NetworkServer.Spawn(obstacle.gameObject);
        }
    }

    internal Vector3 GetPosition(float horizontal, float vertical)
    {
        var left = vertical * topLeft.position + (1 - vertical) * bottomLeft.position;
        var right = vertical * topRight.position + (1 - vertical) * bottomRight.position;
        return horizontal * left + (1 - horizontal) * right;
    }

    internal float GetVertical(Vector3 position)
    {
        var v = topLeft.position - bottomLeft.position;
        var p = Vector3.Project(position - bottomLeft.position, v);
        return p.magnitude / v.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
