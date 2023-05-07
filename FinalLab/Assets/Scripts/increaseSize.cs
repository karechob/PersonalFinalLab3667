using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseSize : MonoBehaviour
{
    [SerializeField] public float timer = 0f;
    [SerializeField] public float growthTime = 6f;
    [SerializeField] public float maxSize = 2f;
    [SerializeField] public bool isMaxSize = false;

    // Start is called before the first frame update
    void Start()
    {
        if(isMaxSize == false) 
        {
            StartCoroutine(Grow());
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
