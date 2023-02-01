using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public AudioClip duckIdleSound;
    public AudioClip duckHitSound;

    Transform duckTransform;
    public float duckSpeed;
    float randomDirection;
    float baseRotationX, BaseRotationZ = 0;
    

    private void Awake()
    {
        duckTransform = this.gameObject.GetComponent<Transform>();
        randomDirection = Random.Range(0, 360);
        
    }

   
    private void Update()
    {
        
        DuckMovement();
    }

    public void DuckMovement()
    {
        gameObject.transform.Translate(Vector3.forward * duckSpeed * Time.deltaTime);
        duckTransform.eulerAngles = new Vector3(0, randomDirection, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit with: " + collision.gameObject.name);
        randomDirection = Random.Range(0, 360);
        
    }
}
