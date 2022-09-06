using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;

    // Start is called before the first frame update
    void Start()
    {
        Cooltime();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {

        if (!Input.GetKeyUp(KeyCode.Z))
            return;

        if (curtime < cooltime)
            return;

        if ( Input.GetKeyUp(KeyCode.Z))
            {
                Instantiate(bullet,pos.position,transform.rotation);
            }
        
        curtime = 0;
    }
    void Reload()
    {
        curtime += Time.deltaTime;
    }

    public void Cooltime()
    {
        cooltime = 0.3f;
    }
}
