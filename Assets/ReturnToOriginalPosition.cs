using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOriginalPosition : MonoBehaviour
{

    public GameObject object_;
    public Vector3 originalPosition;
    public MeshRenderer visible;

    private bool inHand;
    private bool inPosition;

    
    void Awake()
    {
        originalPosition = object_.transform.localPosition;
    }

    
    void Update()
    {

        // Gravity(true) = Not in hand
        // Gravity(false) = Is in hand
        
        // NOT IN HAND
        if (object_.GetComponent<Rigidbody>().useGravity == true && inHand == false) //it is NOT in hand and has not been in hand       NO  NO
        {

            return;
        }


        // IN HAND
        else if (object_.GetComponent<Rigidbody>().useGravity == false && inHand == true) // if it is in hand and has been in hand      YES YES      
        {
            
            return;
        }

        // RELEASED FROM HAND
        else if (object_.GetComponent<Rigidbody>().useGravity == true && inHand == true) //it is NOT in hand but has been in hand       NO  YES
        {
            inHand = false;
            object_.transform.localPosition = originalPosition;
            //MAKE VISIBLEW
            visible.enabled = true;
            return;
        }  

        // GRABBED
        else if (object_.GetComponent<Rigidbody>().useGravity == false && inHand == false) //is in hand but has not been in hand          YES NO
        {
            inHand = true;
            //MAKE INVISIBLE
            visible.enabled = false;
            return;
        }



        else if (object_.GetComponent<Rigidbody>().useGravity == false) //it is in hand
            inHand = true;
        if (object_.transform.localPosition == originalPosition)
            return;
        else
            object_.transform.localPosition = originalPosition;
    }
}
