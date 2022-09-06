using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASUP : item
{
    public GameObject PlayerAttack;
    public override void RunItem()
    {
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
}
