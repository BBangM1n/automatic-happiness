using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField]
    private float power;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    public float maxSpeed;
    float jumpCount = 2;
    public float jumpPower;
    public float playerDmg = 1;
    
    bool isGround;

    

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        //이동 & 모션
        if(Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.0001f, rigid.velocity.y);
            }

        if (Input.GetButtonDown("Jump") && jumpCount > 0){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            jumpCount--;
            } 

        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("moving", false);
        else
            anim.SetBool("moving", true);

    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * hor, ForceMode2D.Impulse);

        // 이동속도 최대값 
        if(rigid.velocity.x > maxSpeed)
           rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))
           rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

        
        if(hor > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (hor < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if(rigid.velocity.y < 0) {
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("ALLFloor"));

         if(rayHit.collider != null) {
             if(rayHit.distance < 0.5f){
                anim.SetBool("jump", false);
                jumpCount = 2; // 더블점프초기화
                }  
            }
        }
    }

    //  void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Item"){
    //     //점수
    //         bool ATUP = collision.gameObject.name.Contains("ATUP");
    //         bool SPUP = collision.gameObject.name.Contains("SPUP");
            
    //         if(ATUP)
    //         {
    //            bullet bullet = collision.gameObject.GetComponent<bullet>();
    //            bullet.Atup();
    //         }
    //         collision.gameObject.SetActive(false);

    //         Debug.Log('됨');
    //     }
    // }

}
