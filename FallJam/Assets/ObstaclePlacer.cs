using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    public Vector2 speedRange = new Vector2(0.25f, 0.75f);
    public Transform root;
    public Transform topLeft;
    public Transform bottomLeft;
    public Transform topRight;
    public Transform bottomRight;

    // Start is called before the first frame update
    void Start()
    {
        var children = root.GetComponentsInChildren<ObstacleController>();
        foreach (var child in children)
        {
            child.speed = Random.Range(speedRange.x, speedRange.y);
            child.top = topLeft;
            child.bottom = bottomLeft;
            child.bottom2 = bottomRight;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
