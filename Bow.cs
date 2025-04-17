using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Animator anime;
    public GameObject arrowPrefab;
    public Transform startPos = null;
    public Transform endPos = null;
    public Transform notchPos = null;

    public float pullValue = 0.0f;
    public Transform hand = null;

    public Arrow current;

    void Awake()
    {
      anime = GetComponent<Animator>();   
    }

    void Start()
    {
        createArrow();   
    }

    public void createArrow(){
        GameObject newArrow = Instantiate(arrowPrefab, notchPos);
        newArrow.transform.SetParent(notchPos);
        newArrow.transform.localPosition = new Vector3(0,0,0.425f);
        newArrow.transform.localEulerAngles = Vector3.zero;
        current = newArrow.GetComponent<Arrow>();
    }

    void Update()
    {
        if(!current || !hand)
        {
            return;
        }
        pullValue = calcPull(hand);
        if(pullValue < 0.0f){
            pullValue = 0.0f;
        }
        if(pullValue > 1.0f){
            pullValue = 1.0f;
        }

        anime.SetFloat("Blend", pullValue);
    }

    public float calcPull(Transform hand){
        return 0.0f;
    }

    public void Pull(Transform handPos){
        
    }

    public void Release(){

    }

}
