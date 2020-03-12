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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != new Vector3 (curPosition.x, transform.position.y, curPosition.z) + nextDir)
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
        }
        
    }

    public void Move()
    {
        rb.AddForce(0, jumpForce, 0);
    }
}
