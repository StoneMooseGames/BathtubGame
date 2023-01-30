using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasLever : MonoBehaviour
{
    [Tooltip("Different speed toggles (NOT INCLUDING STILL AND REVERSE")]
    public int speedLevels;

    [Tooltip("Where levers max rotation is")]
    public float maxLeverRotation;

    [Tooltip("Where levers min rotation is")]
    public float minLeverRotation;

    public GameObject lever;

    private Vector3 leverRotation;

    public bool leverHasBeenMoved;

    // Still + reverse  = 23%
    // Speed            = 77%

    private void Start()
    {
        leverHasBeenMoved = false;
    }

    private void Update()
    {
        leverRotation = lever.transform.rotation.eulerAngles;



        if (leverRotation.x > 0 && leverRotation.x < 25)
        {
            leverRotation.x = 0;
            



            //lever.transform.rotation = Quaternion.Euler(0, lever.transform.rotation.y, lever.transform.rotation.z);
        }
    }

}



