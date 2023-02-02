using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int secondsToDestroy;
    Transform startRotation;
    public Transform turretMuzzle;
    
    private void Awake()
    {
        turretMuzzle = GetComponentInParent<Transform>();
        Destroy(this.gameObject, secondsToDestroy);
        startRotation.rotation = turretMuzzle.rotation;
        this.gameObject.transform.rotation = startRotation.rotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if(collision.gameObject.tag == "Destructible")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
