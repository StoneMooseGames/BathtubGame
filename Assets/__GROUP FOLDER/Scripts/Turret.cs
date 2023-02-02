using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    [Header("General")]
    public GameObject infoScreen;
    public GameObject reLoadScreenText;
    public Quaternion tilt;
    public Quaternion turretRotation;
    public GameObject turretBase;
    public GameObject barrel;
    public int tiltDirection;
    public int rotateDirection;
    public Transform firingPoint;
    public float firingForce;
    public float tiltSpeed;
    public float rotateSpeed;
    [Header("Buttons")]
    public Button tiltButton;
    public Button rotateButton;
    [Header("Ammo")]
    public int ammoCount = 0;
    public int maxAmmoCount = 10;
    public GameObject ammo;
    [Header("Sounds")]
    public AudioClip turretRotationSound;
    public AudioClip turretTiltSound;
    public AudioClip turretFireSound;
    public AudioClip turretReloadSound;
    [Header("Effects")]
    public GameObject firingEffect;
    
    bool isRotating;
    bool isTilting;

    GameObject leftController;
    GameObject rightController;

    // Start is called before the first frame update

    private void Awake()
    {
        leftController = GameObject.Find("LeftHand Controller");
        rightController = GameObject.Find("RightHand Controller");
        GameObject.Find("RotateRight").GetComponent<Button>().GetComponent<Image>().color = Color.red;
    }
    private void Start()
    {
        
        tilt.eulerAngles = new Vector3(-45, 0, 0);
        turretRotation.eulerAngles = new Vector3(-90, 0, 0);
        barrel.transform.rotation = tilt;
        turretBase.transform.rotation = turretRotation;
        ammoCount = maxAmmoCount;
        tiltDirection = 1;
        rotateDirection = 1;
        
        

    }

    private void Update()
    {
        if (isRotating)
        {
            RotateTurret();
        }
        if (isTilting)
        {
            TiltTurret();
        }

        

    }
    public void FireTurret()
    {
        if(ammoCount > 0)
        {
            PlayTurretSound(turretFireSound);
            GameObject newBullet = Instantiate(ammo, firingPoint.transform);
            newBullet.GetComponent<Rigidbody>().AddForce(firingPoint.transform.forward.normalized * firingForce );
            Instantiate(firingEffect);
            
        }
        
    }

    void RotateTurret()
    {
        
        turretRotation.eulerAngles += new Vector3(0, rotateSpeed * rotateDirection, 0);
        tilt.eulerAngles += new Vector3(0, rotateSpeed * rotateDirection, 0);
        turretBase.transform.rotation = turretRotation;
        barrel.transform.rotation = tilt;
       
        
    }

    void TiltTurret()
    {

        if (tilt.eulerAngles.x > 80 || tilt.eulerAngles.x < 10) tiltDirection *= -1;    
            
        tilt.eulerAngles += new Vector3(tiltSpeed * tiltDirection, 0, 0);
        barrel.transform.rotation = tilt;
         
        
    }

    public void ReloadTurret()
    {
        ammoCount = maxAmmoCount;
        PlayTurretSound(turretReloadSound);

        StartCoroutine(WaitTimer(5));
    }

   void PlayTurretSound(AudioClip audioclip)
    {
        AudioSource turretSource = this.gameObject.GetComponent<AudioSource>();
        turretSource.clip = audioclip;
        turretSource.Play();

    }

    public void ToggleRotate()
    {
        isRotating = !isRotating;
        if (isRotating)
        {
            rotateButton.GetComponent<Image>().color = Color.red;
            PlayTurretSound(turretRotationSound);
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            rotateButton.GetComponent<Image>().color = Color.white;
        }
    
    }

    public void ToggleTilting()
    {
        isTilting = !isTilting;
        if (isTilting)
        {
            tiltButton.GetComponent<Image>().color = Color.red;
            PlayTurretSound(turretTiltSound);
        }
        else
        {
            tiltButton.GetComponent<Image>().color = Color.white;
            this.gameObject.GetComponent<AudioSource>().Stop();
        }
        
        
    }

    public void SetRotationDirection(int value)
    {
        GameObject.Find("RotateRight").GetComponent<Button>().GetComponent<Image>().color = Color.white;
        GameObject.Find("RotateLeft").GetComponent<Button>().GetComponent<Image>().color = Color.white;
        if (value == 1) GameObject.Find("RotateRight").GetComponent<Button>().GetComponent<Image>().color = Color.red;
        if (value == -1) GameObject.Find("RotateLeft").GetComponent<Button>().GetComponent<Image>().color = Color.red;
        rotateDirection = value;
    }

    IEnumerator WaitTimer(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
       
}
