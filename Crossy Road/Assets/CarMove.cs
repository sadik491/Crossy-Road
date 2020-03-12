using UnityEngine;
using PathCreation;

public class CarMove : MonoBehaviour
{

    public PathCreator pathCreator;
    public float speed = 5;
    public float distanceTravel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravel += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravel);
    }
}
