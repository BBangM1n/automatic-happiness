using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPUP : item
{
    public override void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player Player = playerObject.GetComponent<Player>();

        Player.maxSpeed += 1.5f;
        Player.jumpPower *= 1.5f;

        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            RunItem();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
