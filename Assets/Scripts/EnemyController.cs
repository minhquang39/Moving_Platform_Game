using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float distance = 5f; 
    private Vector3 startPosition;
    private bool moveRight = true;
 
    void Start()
    {   
        startPosition = transform.position; 
    }

  
    void Update()
    {
        float leftBound = startPosition.x - distance;
        float rightBound = startPosition.x + distance; // Calculate the left and right bounds for enemy movement
        if(moveRight){
            transform.position += Vector3.right * speed * Time.deltaTime; 
            if(transform.position.x >= rightBound){ 
                moveRight = false; 
                Flip(); 
            }
        } else {
            transform.position -= Vector3.right * speed * Time.deltaTime; 
            if(transform.position.x <= leftBound){ 
                moveRight = true; 
                Flip(); 
            }
        }
    }

    void Flip(){
        Vector3 scalerx = transform.localScale;
        scalerx.x *=-1;
        transform.localScale = scalerx; // Flip the enemy sprite by changing its scale
    }
}
