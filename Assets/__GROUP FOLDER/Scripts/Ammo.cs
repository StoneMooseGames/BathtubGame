using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int secondsToDestroy;

    private void Awake()
    {
        Destroy(this.gameObject, secondsToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        Destroy(this.gameObject);
    }
}
