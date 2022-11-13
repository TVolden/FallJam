using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float moveX = 0f;
    public float speed = 0.5f;

    public override void OnStartLocalPlayer()
    {
        //Camera.main.transform.SetParent(transform);
        //Camera.main.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }

        moveX = Input.GetAxis("Horizontal") * speed;

        transform.Translate(moveX, 0, 0);
    }
}
