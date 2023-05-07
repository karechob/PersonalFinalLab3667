using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float SPEED = 5f;
    
    
    void Start()
    {
        rb.velocity = transform.right * SPEED;
    }
    void OnTriggerEnter2D(Collider2D hit) 
    {
        Debug.Log(hit.name);
        Destroy(gameObject);
    }
}
