using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Transform pointA; 
    [SerializeField] private Transform pointB; 
    [SerializeField] private float speed = 2f; 
    private Vector3 targetPosition; 
    private Transform player;   

    void Start()
    {
        targetPosition = pointA.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
        if(Vector3.Distance(transform.position,targetPosition)<0.1f){ 
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position; 
        }
    }


}
