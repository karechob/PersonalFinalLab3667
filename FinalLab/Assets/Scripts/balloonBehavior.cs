using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonBehavior : MonoBehaviour
{
    private Animator balloonPop;
    // Start is called before the first frame update
    void Start()
    {
        balloonPop = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonPopped() == true)
        balloonPop.SetBool("IsPopped", true);
    }

    bool balloonPopped()
    {
        return false;
    }
}
