using UnityEngine;

public class SawBlade : MonoBehaviour
{
     [SerializeField] private float swingAngle = 45f; // Góc lắc tối đa
    [SerializeField] private float swingSpeed = 2f;  // Tốc độ lắc
    private float startRotation;

    void Start() 
    {
        startRotation = transform.eulerAngles.z;
    }

    void Update() 
    {
        float swing = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, startRotation + swing);
    }
}
