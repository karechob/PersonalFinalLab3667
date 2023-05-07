using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject pinPreFab;
    private Animator kirbAnimation; 

    // void Start() {
    //     kirbAnimation = GetComponent<Animator>();
    // }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        Instantiate(pinPreFab, firePoint.position, firePoint.rotation);
    }
}
