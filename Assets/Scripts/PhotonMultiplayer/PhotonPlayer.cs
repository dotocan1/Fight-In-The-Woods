using UnityEngine;
using Photon.Pun;
public class PhotonPlayer : MonoBehaviour
{
    PhotonView view;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        view.RPC("playerTag", RpcTarget.AllBuffered, gameObject.tag);
    }

    [PunRPC]
    void playerTag(string text)
    {
        this.tag = text;
    }
    
}
