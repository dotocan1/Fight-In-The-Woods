using System.Collections;
using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
public class Combat : MonoBehaviour
{
    public float thrust = 50.0f;

    PhotonView view;
    private Animator animator;
    private Damage damageScript;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        Combat combatScript = GetComponent<Combat>();

        if (!view.IsMine)
        {
            combatScript.enabled = false;
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<PhotonPlayer>().health <= 0f)
        {
            
            if (gameObject.tag == "Team_1" || gameObject.tag == "Team_2")
            {
                StartCoroutine(DestroyObject(gameObject));
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
            } else
            {
                PhotonNetwork.Destroy(gameObject);
            }
           
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 300f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeGoodMageFire()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 50f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeArrowCircleDamage()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 150f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeGroundSlashDamage()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 150f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeSingleArrowDamage()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 400f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void healPlayer()
    {
        gameObject.GetComponent<PhotonPlayer>().health += 300.0f;
        Debug.Log("Healing! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeSwordDamage()
    {
        
        if (gameObject.GetComponent<Ability>() != null && gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        // ovo ce se koristit za provjeru ako je u animaciji
        gameObject.GetComponent<PhotonPlayer>().health -= 50f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeProjectileDamage()
    {
        if (gameObject.GetComponent<Ability>().isShield)
        {
            return;
        }
        gameObject.GetComponent<PhotonPlayer>().health -= 50f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    private IEnumerator DestroyObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.Destroy(gameObject);
    }
}
