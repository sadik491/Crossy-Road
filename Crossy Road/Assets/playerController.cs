using UnityEngine;

public class playerController : MonoBehaviour
{
    public Vector3 nextDir;
    public Rigidbody rb;
    public float jumpForce = 100f;
    public Vector3 curPosition;
    public float speed = 5;
    public float speedRot = 1000f;
    public float rotationOffset;

    //Swipe Varriable

    public float maxTime;
    public float minSwipeDist;

    public float startTime;
    public float endTime;

    public Vector3 startPos;
    public Vector3 endPos;

    public float swipeDistance;
    public float swipeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curPosition = transform.position;
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


        /*if (transform.position != new Vector3 (curPosition.x, transform.position.y, curPosition.z) + nextDir)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(curPosition.x, transform.position.y, curPosition.z) + nextDir, speed*Time.deltaTime);
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Quaternion.Euler(0, rotationOffset, 0) * nextDir), speedRot * Time.deltaTime);
        }

        else
        {
            nextDir = Vector3.zero;
            curPosition = transform.position;
            curPosition.x = Mathf.Round(curPosition.x);
            curPosition.y = Mathf.Round(curPosition.y);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                nextDir.x = Input.GetAxisRaw("Horizontal");
                Move();

            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                nextDir.z = Input.GetAxisRaw("Vertical");
                Move();
            }
        }*/
        
    }

    public void Move()
    {
        rb.AddForce(0, jumpForce, 0);
    }

    void Swipe()
    {
        Vector2 distance = endPos - startPos;

        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            //Debug.Log("Horizontal");
            if (distance.x < 0)
            {
                rb.AddForce(-100, jumpForce, 0);
                //Debug.Log("left Swipe");

            }
            if (distance.x > 0)
            {
                rb.AddForce(100, jumpForce, 0);
                //Debug.Log("Right Swipe");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            //Debug.Log("Vertical");
            if (distance.y < 0)
            {
                rb.AddForce(0, jumpForce, -100);
                //Debug.Log("down Swipe");
            }
            if (distance.y > 0)
            {
                rb.AddForce(0, jumpForce, 100);
                //Debug.Log("up Swipe");
            }
        }
    }
}
