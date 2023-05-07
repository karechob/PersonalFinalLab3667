using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bubblePreFab;
    [SerializeField] float timer = 2f;

    void Update() 
    {
        ShootBubble();
    }
    void ShootBubble() 
    {
        timer -= Time.deltaTime;
             if (timer <= 0f)
            {
         Instantiate(bubblePreFab, firePoint.position, firePoint.rotation);
         timer = 2f;
    }
    }
}

