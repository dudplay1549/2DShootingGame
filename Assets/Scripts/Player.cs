using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public int life;
    public int score;
    public float speed;
    public int maxPower;
    public int power;
    public int maxBoom;
    public int boom;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject boomEffect;
    public GameManager manager;
    
    public bool isHit;
    public bool isBoomTime;

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
        Boom();
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
        //if (!Input.GetKeyDown(KeyCode.Z))
            //return;

        if (curShotDelay > maxShotDelay)
            return;

        switch (power)
        {
            case 0:
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 1: //case 0:과 동일, 팔로워 기체 코딩 누락
                break;
            case 2: //팔로워 기체 코딩 누락
                GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);
                GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.1f, transform.rotation);
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse); 
                rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 3: //팔로워 기체 코딩 누락
                GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.2f, transform.rotation);
                GameObject bulletCC = Instantiate(bulletObjA, transform.position, transform.rotation);
                GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.2f, transform.rotation);
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            
            case 4: //팔로워 기체 코딩 누락
                GameObject bulletLLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.2f, transform.rotation);
                GameObject bulletCCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletRRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.2f, transform.rotation);
                Rigidbody2D rigidLLL = bulletLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCC = bulletCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRR = bulletRRR.GetComponent<Rigidbody2D>();
                rigidLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            
            case 5: //팔로워 기체 코딩 누락
                GameObject bulletLLLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.2f, transform.rotation);
                GameObject bulletRRRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.2f, transform.rotation);
                Rigidbody2D rigidLLLL = bulletLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRR = bulletRRRR.GetComponent<Rigidbody2D>();
                rigidLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 6: //팔로워 기체 코딩 누락
                GameObject bulletLLLLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.2f, transform.rotation);
                GameObject bulletCCCCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletRRRRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.2f, transform.rotation);
                Rigidbody2D rigidLLLLL = bulletLLLLL.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCCCC = bulletCCCCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidRRRRR = bulletRRRRR.GetComponent<Rigidbody2D>();
                rigidLLLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCCCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidRRRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }

    curShotDelay = 0;
    
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Boom()
    {
        if (!Input.GetButton("Fire2"))
            return;

        if (isBoomTime)
            return;

        if (boom == 0)
            return;
        
        boom--;
        isBoomTime = true;
        manager.UpdateBoomIcon(boom);

        //#1.Effect visible
        boomEffect.SetActive(true);
        Invoke("OffBoomEffect", 4f);

        //#2.Remove Enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int index = 0; index < enemies.Length; index++)
        {
            Enemy enemyLogic = enemies[index].GetComponent<Enemy>();
            enemyLogic.OnHit(1000);
        }

        //#3.Remove Enemy Bullet
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Enemy");
        for (int index = 0; index < bullets.Length; index++)
        {
            Destroy(bullets[index]);
        }
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

        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
                return;

            isHit = true;
            life--;
            manager.UpdateLifeIcon(life);

            if(life == 0)
            {
                manager.GameOver();
            }
            else
            {
                manager.RespawnPlayer();
            }

            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    score += 1000;
                    break;

                case "Power":
                    if (power == maxPower)
                        score += 500;
                    else
                        power++;
                    break;

                case "Boom":
                    if (boom == maxBoom)
                        score += 500;
                    else
                    {
                        boom++;
                        manager.UpdateBoomIcon(boom);
                    }
                        boom++;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
        isBoomTime = false;
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
