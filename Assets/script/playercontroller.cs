using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    public float speed = 1.2f;
    public float forceSpd = 0.9f;
    public GameObject player;

    public float distance = 6.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Vector3 offset;
    public float force = 0.0f;

    float x = 0.0f;
    float y = 0.0f;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        offset = transform.position - player.transform.position;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }
    void LateUpdate ()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                gameObject.transform.position = originalPos;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                
            }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            gameObject.transform.position = originalPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if(Input.GetMouseButton(0))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (float)2, gameObject.transform.position.z);
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5,
                                    distanceMin, distanceMax);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            offset = rotation * negDistance;
            transform.rotation = rotation;
        }

        
        if(Input.GetMouseButton(1))
        {
            force += Time.deltaTime*forceSpd;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Vector3 movement = Camera.main.transform.forward;
            movement.y = 0.0f;
            rb.AddForce(movement * speed * force, ForceMode.Impulse);
            force = 0.0f;
        }
    }
    public static float ClampAngle (float angle, float min, float max)
    {
        if(angle < -360f) angle += 360f;
        if(angle > -360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
    
    void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();

            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    
    // Update is called once per frame
    /*void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }*/
    
    void OnTriggerEnter (Collider other)
    {
        
        if(other.gameObject.CompareTag("dynamiccollider"))
            other.gameObject.SetActive(false);
        
    }
}


