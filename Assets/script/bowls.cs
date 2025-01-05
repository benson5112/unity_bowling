using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class bowls : MonoBehaviour
{
    public GameObject winTextObject;

    private Rigidbody rb;
    private static int count = 0;
    private Vector3 originalPos;
    private Quaternion originalrotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalrotate = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0.0f);

        SetCountText();
        winTextObject.SetActive(false);
    }
    void LateUpdate ()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                gameObject.transform.position = originalPos;
                gameObject.transform.rotation = new Quaternion(originalrotate.x, originalrotate.y, originalrotate.z, 0.0f);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if(gameObject.transform.position != originalPos)
                {
                    gameObject.SetActive(false);
                }
                gameObject.transform.position = originalPos;
                gameObject.transform.rotation = new Quaternion(originalrotate.x, originalrotate.y, originalrotate.z, 0.0f);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
    }

    void SetCountText()
    {
        if(count >= 10)
        {
            winTextObject.SetActive(true);
        }
        
    }
    private void OnTriggerEnter (Collider other)
    {
        if(Mathf.Abs(gameObject.transform.position.y)>0.3)
            {
                count = count + 1;
            }
        
    }
    
        /*if()
        {
            gameObject.transform.position= new Vector3((float)0,(float)0.5,(float)0);
            Rigidbody rb= other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }*/
        
    
}

