using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTester : MonoBehaviour
{
    public float maxTime;
    public float minSwipeDist;
    
    public float startTime;
    public float endTime;

    public Vector3 startPos;
    public Vector3 endPos;

    public float swipeDistance;
    public float swipeTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    Swipe();
                }
            }
        }

        
    }
    void Swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("Horizontal Swipe");
            if (distance.x < 0)
            {
                Debug.Log("left Swipe");
            }
            if (distance.x > 0)
            {
                Debug.Log("Right Swipe");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            Debug.Log("Vertical Swipe");
            if (distance.y < 0)
            {
                Debug.Log("down Swipe");
            }
            if (distance.y > 0)
            {
                Debug.Log("up Swipe");
            }
        }
    }
}
