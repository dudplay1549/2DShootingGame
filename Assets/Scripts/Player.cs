using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchLeft && h == -1) || (isTouchRight && h == 1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") ||
           Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    void Fire()
    {
        //if (!Input.GetButton("Fire1"))
            //return;

        if (curShotDelay > maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 2:
                GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);
                GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.1f, transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse); 
                rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 3:
                GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletCC = Instantiate(bulletObjA, transform.position, transform.rotation);
                GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            
            case 4:
                GameObject bulletLLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletCCC = Instantiate(bulletObjA, transform.position, transform.rotation);
                GameObject bulletRRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletF = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject bulletFF = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D rigidLLL = bulletLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCC = bulletCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRR = bulletRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidF1 = bulletRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidF2 = bulletRRR.GetComponent<Rigidbody2D>();
                rigidLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidF1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidF2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            
            case 5:
                GameObject bulletLLLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletCCCC = Instantiate(bulletObjC, transform.position, transform.rotation);
                GameObject bulletRRRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletFF1 = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject bulletFF2 = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D rigidLLLL = bulletLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCCC = bulletCCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRR = bulletRRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFF1 = bulletFF1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFF2 = bulletFF2.GetComponent<Rigidbody2D>();
                rigidLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFF1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFF2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 6:
                GameObject bulletLLLLL = Instantiate(bulletObjC, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletRRRRR = Instantiate(bulletObjC, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletFFF1 = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject bulletFFF2 = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D rigidLLLLL = bulletLLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRRR = bulletRRRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFFF1 = bulletFFF1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFFF2 = bulletFFF2.GetComponent<Rigidbody2D>();
                rigidLLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFFF1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFFF2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 7:
                GameObject bulletLLLLLL = Instantiate(bulletObjC, transform.position + Vector3.left * 0.25f, transform.rotation);
                GameObject bulletCCCCCC = Instantiate(bulletObjC, transform.position, transform.rotation);
                GameObject bulletRRRRRR = Instantiate(bulletObjC, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletFFFF1 = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject bulletFFFF2 = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D rigidLLLLLL = bulletLLLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCCCCC = bulletCCCCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRRRR = bulletRRRRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFFFF1 = bulletFFFF1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidFFFF2 = bulletFFFF2.GetComponent<Rigidbody2D>();
                rigidLLLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCCCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFFFF1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidFFFF2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }

    curShotDelay = 0;
    
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch(collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
