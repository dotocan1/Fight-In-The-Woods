using UnityEngine;
using Photon.Pun;
public class PhotonPlayer : MonoBehaviour
{
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        view.RPC("playerTag", RpcTarget.AllBuffered, gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void playerTag(string text)
    {
        this.tag = text;
    }
}
