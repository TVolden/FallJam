using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float moveX = 0f;
    public float speed = 0.5f;
    public string name;
    public ObstaclePlacer placer;

    public override void OnStartLocalPlayer()
    {
        placer = FindObjectOfType<ObstaclePlacer>();
        //Camera.main.transform.SetParent(transform);
        //Camera.main.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }
        moveX = Input.GetAxis("Horizontal") * speed;
        transform.Translate(moveX, 0, 0);
        
        var v = placer.GetVertical(transform.position);
        if (v > 1 || v < 0)
        {
            Debug.Log("You dead!");
        }
    }

    [ServerCallback]
    void LateUpdate()
    {
        var v = placer.GetVertical(transform.position);
        if (v > 1 || v < 0)
        {
            NetworkServer.Destroy(gameObject);
        }
    }


}
