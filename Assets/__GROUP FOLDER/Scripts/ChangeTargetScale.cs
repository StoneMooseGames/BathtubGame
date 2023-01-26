using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTargetScale : MonoBehaviour
{
    public Transform target;
    public Vector3 newScale;
    private Vector3 oldScale;




    private void Start()
    {
        oldScale = target.transform.localScale;
    }


    public void ApplyNewScale()
    {
        target.transform.localScale = newScale;
    }



    public void ApplyOldScale()
    {
        target.transform.localScale = oldScale;
    }

}

