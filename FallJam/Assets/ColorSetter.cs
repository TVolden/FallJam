using Mirror;
using UnityEngine;

public class ColorSetter : NetworkBehaviour
{
    public void Update()
    {
      Color color = new Color(0f, 0f, 1f);
      NetworkIdentity identity = GetComponent<NetworkIdentity>();
      if (identity.connectionToClient.connectionId == 0)
      {
        color = new Color(1f, 0f, 0);
      }
      Material playerMaterialClone = new Material(GetComponent<Renderer>().material);
      playerMaterialClone.color = color;
      GetComponent<Renderer>().material = playerMaterialClone;
    }
}
