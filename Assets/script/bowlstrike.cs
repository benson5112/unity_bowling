using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class bowlstrike : MonoBehaviour
{
    public GameObject winTextObject;

    private Rigidbody rb;
    private static int count = 0;
    private Vector3 originalPos;
    private Quaternion originalrotate;
    private Vector3 bowlpos;
    private Quaternion bowlrota;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalrotate = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0.0f);

        var bowl = FindObjectOfType<bowls>();
        bowlpos = new Vector3(bowl.transform.position.x, bowl.transform.position.y, bowl.transform.position.z);
        bowlrota = new Quaternion(bowl.transform.rotation.x, bowl.transform.rotation.y, bowl.transform.rotation.z, 0);

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        if(count >= 10)
        {
            winTextObject.SetActive(true);
        }
        
    }
    private void FixedUpdate ()
    {
        if(Mathf.Abs(bowlrota.x) > 0.3 || Mathf.Abs(bowlrota.z) > 0.3)
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

