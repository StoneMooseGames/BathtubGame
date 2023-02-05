using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    //some gameobject where rotation can be taken from;
    public GameObject wheel;

    private float wheelRotation;

    public UnityEvent TurnRight;
    public UnityEvent TurnLeft;



    private void Start()
    {
        
    }

    private void Update()
    {
        wheelRotation = wheel.transform.localRotation.eulerAngles.x;

        //Debug.Log(wheel.transform.localRotation.eulerAngles.x);

        if (wheelRotation <= 5)
            return;

        else if(wheelRotation > 300)
            TurnRight.Invoke();

       else if(wheelRotation > 20)
            TurnLeft.Invoke();  

        // Ship Controls:
        //      public void TurnShip (float amount)
        //      {
        //          ship.transform.rotation += amount;
        //      }

        // Will the 


        // if this does not work, add a bool to rotation
        //      when value is bigger than 0 = rotation(true)
        //      when value is less than 0   = rotation(false)
        // and while rotation is true, the ship will keep rotating with the assigned value (-45 or 45) untill rotation is set to false.


        // if(wheelRotation < 5)
        //      TurnStop.invoke(0)        sends the "RotateShip" function a 0 which will make rotate = false;
        // else if(wheelRotation > 300)
        //      TurnRight.invoke(-45);    number is about the value which will be assigned to the rotation function (if that works)
        // else if(wheelRotation > 40)
        //      TurnLeft.invoke(45); 


        // Ship Controls:
        //      public void TurnShip (float amount)
        //      {
        //          if (amount = 0 && rotation = true)
        //              rotation = false
        //              return;
        //          
        //
        //          if (amount != 0 && rotation = true)
        //              ship.transform.rotation += amount;
        //      }




        //Debug.Log(wheel.transform.rotation.x);
        //Debug.Log(wheel.gameObject.transform.rotation.x);
        
        //Debug.Log(wheel.transform.localRotation.x);

        // Add events which listen to how much the wheel has been rotated.
        // The events send to the "rotate ship" the float depending on what way the ship is going to turn;

        // n < 5   -> Stay Still
        // n > 300 -> Turn right
        // n > 40  -> Turn left

    }
}
