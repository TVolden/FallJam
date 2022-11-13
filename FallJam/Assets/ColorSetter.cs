using Mirror;
using UnityEngine;

public class ColorSetter : NetworkBehaviour
{
    // [ServerCallback]
    // public void Start()
    // {

    // }

    // [ServerCallback]
    // public void Awake()
    // {

    // }

    public void Update()
    {
      Color color = Color.blue;
      NetworkIdentity identity = transform.parent.GetComponent<NetworkIdentity>();
      if (identity.connectionToClient.connectionId != 0)
      {
        color = Color.red;
      }
      Material material = GetComponent<Renderer>().material;
      material.color = color;
    }
}
