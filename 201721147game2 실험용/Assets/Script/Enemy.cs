using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Maxhp;
    public float Nowhp;
    public EnemyHP enemyhp;

    void Start()
    {
        Maxhp = 5;
        Nowhp = 5;
        enemyhp.SetHealth(Nowhp, Maxhp);
    }

    void die(float Dmg)
    {
        Nowhp -= Dmg;
        enemyhp.SetHealth(Nowhp, Maxhp);
        if(Nowhp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거됨");
        if(collision.gameObject.tag == "Attack")
        {
            GameObject playerObject = GameObject.Find("Player");
            Player Player = playerObject.GetComponent<Player>();
            bullet bullet = collision.gameObject.GetComponent<bullet>();

            die(Player.playerDmg);

            bullet.DestroyBulley();
        }
    }
}
