using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ProceduralContentGenerator : NetworkBehaviour
{
    public Transform obstacles;

    // Start is called before the first frame update
    void Start()
    {
        if(obstacles == null)
            enabled = false;
    }

    // Update is called once per frame
    [ServerCallback]
    void Update()
    {
        var children = obstacles.GetComponentsInChildren<ObstacleController>();
        foreach(var child in children)
        {
            if (child.vertical > 1)
            {
                child.horizontal = Random.Range(0.0f, 1.0f);
                child.MoveToBottom();
            }
        }
    }
}
