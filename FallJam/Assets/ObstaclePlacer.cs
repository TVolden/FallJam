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
            obstacle.top = topLeft;
            obstacle.bottom = bottomLeft;
            obstacle.bottom2 = bottomRight;
            obstacle.transform.parent = root;
            obstacle.MoveToBottom();
            NetworkServer.Spawn(obstacle.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
