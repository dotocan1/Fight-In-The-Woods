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

        if (gameObject.GetComponent<PhotonPlayer>().health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("isDead", true);
            Destroy(gameObject, 5f);
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 300f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeGoodMageFire()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 50f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeArrowCircleDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 150f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeGroundSlash()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 150f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeSingleArrowDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 400f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void healPlayer()
    {
        gameObject.GetComponent<PhotonPlayer>().health += 300.0f;
        Debug.Log("Healing! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeSwordDamage(GameObject character)
    {
        // ovo ce se koristit za provjeru ako je u animaciji
        Animator a_animator = character.GetComponent<Animator>();
        if (a_animator.GetBool("isSwordAttacking"))
        {
            gameObject.GetComponent<PhotonPlayer>().health -= 50f;
            Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
        }
    }
}
