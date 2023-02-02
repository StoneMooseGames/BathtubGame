using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [Header("General")]
    public float speed = 1;
    public bool engineOn = false;

    [Header("Ship")]
    public GameObject ship;
    public Rigidbody shipRigidbody;
    public Transform shipParent;

    [Header("Wheel")]
    public GameObject wheel;
    public Rigidbody wheelRigidbody;


    [Header("Player")]
    public GameObject player;
    public bool playerIsChild = true;

    [Header("Sounds")]
    public AudioSource engineOnSound;
    public AudioSource engineOffSound;
    public AudioSource ocean1;
    public AudioSource ocean2;
    public AudioSource ocean3;



    void Start()
    {
        wheelRigidbody = wheel.GetComponent<Rigidbody>();
        shipRigidbody = ship.GetComponent<Rigidbody>();
        shipParent = ship.transform;

        TogglePlayerChildToShip(true);

        //RotateShip(45);
    }


    void Update()
    {
        if (!playerIsChild)
        {
            if (engineOn)
            {
                engineOn = false;
                PlaySound(engineOn);
            }
                

            return;
        }
            
            
        if (!engineOn)
            return;
        else
        {
            //Move the boat
            //ship.transform.position += transform.forward * speed;
            //shipRigidbody.AddForce(ship.transform.forward * speed);
            //shipRigidbody.velocity += transform.forward * speed;
            //ship.transform.position = new Vector3(0, 0, speed) * Time.deltaTime;
            //ship.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //ship.transform.position += transform.forward * speed * Time.deltaTime;
            //shipRigidbody.velocity += transform.forward * speed;
            //shipRigidbody.velocity += new Vector3(0, speed, 0);

            shipRigidbody.AddForce(ship.transform.forward * speed);
            wheelRigidbody.AddForce(wheel.transform.forward * speed);



            #region shipRigidbody.velocity += transform.forward * speed;
            //shipRigidbody.velocity += transform.forward * speed;
            #endregion

        }

    }



    public void ToggleEngine(bool engine)
    {
        engineOn = engine;
        PlaySound(engine);
    }

    private void PlaySound(bool state)
    {
        if (state)
        {
            engineOnSound.Play();
            ocean1.Play();
            ocean2.Play();
            ocean3.Play();
        }
        else
        {
            engineOnSound.Stop();
            engineOffSound.Play();
            ocean1.Stop();
            ocean2.Stop();
            ocean3.Stop();
        }
    }



    public void TogglePlayerChildToShip(bool toggle)
    {
        // If engine is on and the player is not a child anymore
        // (probably has teleported out of the ship) -> the engine will turn off
        if (engineOn)
            engineOn = toggle;


        // Assigns player as a child to the ship depending on if they are a child or not.
        playerIsChild = toggle;

    
        if (playerIsChild)
            player.transform.SetParent(shipParent);
        else
            player.transform.SetParent(null);
    }

    public void RotateShip(float amount)
    {
        ship.transform.Rotate(0, amount, 0);
    }

}

