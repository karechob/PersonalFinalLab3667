using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class balloonMovement : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] Rigidbody2D brb;
    [SerializeField] Transform NextPos;
    int NextPosIndex;
    [SerializeField] float speed;
    // bool balloonPopped = false;
    private Animator balloon; 
    public int scorePoints = 0;
    // bool BalloonPoppedEffect = false;

    [SerializeField] public float timer = 0f;
    [SerializeField] public float growthTime = 6f;
    [SerializeField] public float maxSize = 2f;
    [SerializeField] public bool isMaxSize = false;

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] GameObject controller;
    
    void Start()
    {
         if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        brb = GetComponent<Rigidbody2D>();
        balloon = GetComponent<Animator>();
        NextPos = Positions[0];
        if(isMaxSize == false) 
        {
            StartCoroutine(Grow());
        }  
    }

    // Update is called once per frame
    void Update()
    {
        MoveBalloon();
        BalloonMaxed();
    }
    void MoveBalloon() {
        if(transform.position == NextPos.position) 
        {
             NextPosIndex++;
             if (NextPosIndex >= Positions.Length)
             {
                NextPosIndex = 0;
             }
            NextPos = Positions[NextPosIndex];
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }
    private IEnumerator Grow() 
    {
        Vector2 startSize = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do 
        {
            transform.localScale = Vector3.Lerp(startSize, maxScale, timer / growthTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while(timer < growthTime);

        isMaxSize = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") 
        {
              Physics2D.IgnoreLayerCollision(7, 8, true);
        }   
    }
    public void BalloonHit() {
        Pop();
        Invoke("ballonBehavior", 0.1f);

    }
    public void Pop() 
    {
        balloon.Play("balloonPop");
        audioPlayer.Play();
        Destroy(gameObject, 0.3f);
    }
    public void ballonBehavior() {
        if (transform.localScale.x < 2.0f) {
            scorePoints = 10;
            Debug.Log("current points: " + scorePoints);
            controller.GetComponent<Scorekeeper>().AddPointsBonus();
        } else {
            scorePoints = 5;
            Debug.Log("current points: " + scorePoints);
            controller.GetComponent<Scorekeeper>().AddPoints();
        }
        controller.GetComponent<Scorekeeper>().AdvanceScene();
    } 
    public void BalloonMaxed() 
    {
        if(isMaxSize == true) {
            balloon.Play("balloonPop");
            audioPlayer.Play();
            Destroy(gameObject, 0.3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }

}


