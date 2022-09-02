using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBulley",2);
        dmg = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Enemy")
            {
                Debug.Log("명중");
            }
            DestroyBulley();
        }

        if(transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
    }

    public void DestroyBulley()
    {
        Destroy(gameObject);
    }

    
}
