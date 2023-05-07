using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinMove : MonoBehaviour
{
    [SerializeField] public float SPEED = 20f;
    [SerializeField] public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * SPEED;
    }
    void OnTriggerEnter2D(Collider2D hit) 
    {
        Debug.Log(hit.name);
        balloonMovement balloon = hit.GetComponent<balloonMovement>();
        if (balloon != null) 
        {
            balloon.BalloonHit();
        }
        BombBehavior bomb = hit.GetComponent<BombBehavior>();
        if(bomb != null) 
        {
            bomb.BombHit();
        }
        Destroy(gameObject);

    }
}
