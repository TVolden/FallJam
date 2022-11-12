using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    public Transform root;
    public Transform topLeft;
    public Transform bottomLeft;
    public Transform topRight;
    public Transform bottomRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var children = root.GetComponentsInChildren<ObstacleController>();
        foreach (var child in children)
        {
            var left = child.vertical * topLeft.position + (1-child.vertical) * bottomLeft.position;
            var right = child.vertical * topRight.position + (1-child.vertical) * bottomRight.position;
            child.transform.position = child.horizontal * left + (1 - child.horizontal) * right;
        }
    }
}
