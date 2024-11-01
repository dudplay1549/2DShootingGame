using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float maxShotDelay;
    public float curShotDelay;
    //public int maxPower;
    //public int power;
    public ObjectManager objectManager;

    public Vector3 followPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPos;    //Queue = FIFO (First Input First Out)

    private void Awake()
    {
        parentPos = new Queue<Vector3>();
    }

    void Update()
    {
        Watch();
        Follow();
        Fire();
        Reload();
    }

    void Watch()    //나중에 수정할 것
    {
        //Input Pos
        if (!parentPos.Contains(parent.position))
        {
            parentPos.Enqueue(parent.position);
        }
            
        //Output Pos
        if(parentPos.Count > followDelay)
        {
            followPos = parentPos.Dequeue();
        }
        else if (parentPos.Count < followDelay)
        {
            followPos = parent.position;
        }
    }

    void Follow()
    {
        transform.position = followPos;
    }

    void Fire()
    {
        if (!Input.GetKeyDown(KeyCode.Z))
        return;

        if (curShotDelay > maxShotDelay)
            return;

        GameObject bullet = objectManager.MakeObj("BulletFollower");
        bullet.transform.position = transform.position;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        
        curShotDelay = 0;

        //switch (power)
        //{ 
            //case 0:
                //GameObject bullet = objectManager.MakeObj("BulletFollower");
                //bullet.transform.position = transform.position;

                //Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                //rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                //break;
                
            //case 1:
                //GameObject bulletL = objectManager.MakeObj("BulletFollower");
                //bulletL.transform.position = transform.position + Vector3.left * 0.1f;
                //GameObject bulletR = objectManager.MakeObj("BulletFollower");
                //bulletR.transform.position = transform.position + Vector3.right * 0.1f;

                //Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                //Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                //rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                //rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                //break;
        //}
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}