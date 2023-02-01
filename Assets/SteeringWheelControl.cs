using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelControl : MonoBehaviour
{
    /*
    public GameObject rightHand;
    private Transform rightHandOriginalParent;
    private bool rightHandOnWheel = false;

    public GameObject leftHand;
    private Transform leftHandOriginalParent;
    private bool leftHandOnWheel = false;

    public Transform[] snapPositions;

    public GameObject Vechile;
    private Rigidbody VechileRigidBody;

    public float currentWheelRotation = 0;

    private float turnDampening = 250;

    public Transform directionalObject;
    */

    //some gameobject where rotation cxan be taken from;
    public GameObject wheel;

    private float wheelRotation;



    private void Start()
    {
        
    }

    private void Update()
    {
        // if(wheelRotation < 5)
                //return
        // if(wheelRotation > 300)
                //TurnRight.invoke(-45);    number is about the value which will be assigned to the rotation function (if that works)
        // if(wheelRotation > 40)
                //TurnLeft.invoke(45);

        //Debug.Log(wheel.transform.rotation.x);
        //Debug.Log(wheel.gameObject.transform.rotation.x);
        Debug.Log(wheel.transform.localRotation.eulerAngles.x);

        // Add events which listen to how much the wheel has been rotated.
        // The events send to the "rotate ship" the float depending on what way the ship is going to turn;

        // n < 5   -> Stay Still
        // n > 300 -> Turn right
        // n > 40  -> Turn left

    }
}
