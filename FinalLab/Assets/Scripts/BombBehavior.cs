using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public float pushForce = 0.5f;
    public float collisionDelay = 1f; // the delay time in seconds

    private bool canCollide = true;
    private Vector3 playerStartingPos;
    

    private void Start()
    {
        playerStartingPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canCollide)
        {
            Vector2 direction = collision.transform.position - transform.position;
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(direction.normalized * pushForce, ForceMode2D.Impulse);

            canCollide = false; // disable collision for a period of time
            Invoke("EnableCollision", collisionDelay); // enable collision after delay

            // set the player back to their starting position
            collision.gameObject.transform.position = playerStartingPos;
        }
    }

    private void EnableCollision()
    {
        canCollide = true;
    }
    public void BombHit() {
        Destroy(gameObject);
    }
}










