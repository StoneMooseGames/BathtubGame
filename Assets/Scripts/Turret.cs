using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public int ammoCount = 0;
    public int maxAmmoCount = 10;
    public Quaternion tilt;
    public Quaternion turretRotation;
    public GameObject turretBase;
    public GameObject barrel;
    public GameObject ammo;
    public int tiltDirection;
    public int rotateDirection;
    public Transform firingPoint;
    
    
    // Start is called before the first frame update

    private void Start()
    {
        tilt.eulerAngles = new Vector3(0.5f, 0, 0);
        turretRotation.eulerAngles = new Vector3(0, 0.5f, 0);
        barrel.transform.rotation = tilt;
        turretBase.transform.rotation = turretRotation;
        ammoCount = maxAmmoCount;
        tiltDirection = 1;
        rotateDirection = 1;
        

    }

    private void Update()
    {
        

    }
    public void FireTurret()
    {
        if(ammoCount > 0)
        {
            Debug.Log("Fire Turret");
        }
    }

    public void RotateTurret()
    {
        float turnByAmount = 0.1f;
        turretRotation.eulerAngles += new Vector3(0, turnByAmount * rotateDirection, 0);
        tilt.eulerAngles += new Vector3(0, turnByAmount * rotateDirection, 0);
        turretBase.transform.rotation = turretRotation;
        barrel.transform.rotation = tilt;

    }

    public void TiltTurret()
    {
        float tiltByAmount = 0.1f;
        tilt.eulerAngles += new Vector3(tiltByAmount * tiltDirection, 0, 0);
        barrel.transform.rotation = tilt;
    }

    public void ReloadTurret()
    {
        ammoCount = maxAmmoCount;
        //Wait Timer here, maybe 5 sek?
    }

    public void SetTilttDirection(int direction) //this can be -1 or 1(If zero is used turret wont tilt
    {
        tiltDirection = direction;
    }

    public void SetRotateDirection(int direction)
    {
        rotateDirection = direction;
    }

   
}
