using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelControl : MonoBehaviour
{
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


    private void Start()
    {
        
    }
}
