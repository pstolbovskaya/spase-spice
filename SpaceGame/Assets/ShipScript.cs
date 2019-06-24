using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float speed;
    public float tilt;
    
    public GameObject laserShot;
    public GameObject leftLaser;
    public GameObject rightLaser;

    private float shotDelay = 0.5f;
    private float nextShot = 0;
    private float xMax, xMin, zMax, zMin;
    
    

    // Start is called before the first frame update
    void Start()
    {
        xMax = 65;
        xMin = -65;
        zMax = 30;
        zMin = -10;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorixontal = Input.GetAxis("Horizontal");
        
        Rigidbody ship = GetComponent<Rigidbody>();
        ship.velocity = new Vector3(moveHorixontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(0, 0, - moveHorixontal * tilt);
    
        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        float yPosition = ship.position.y;

        ship.position = new Vector3(xPosition, yPosition, zPosition);


        if (Time.time > nextShot && Input.GetButton("Fire1"))
        {
            nextShot =Time.time + shotDelay;
            Instantiate (laserShot, leftLaser.transform);
            Instantiate (laserShot, rightLaser.transform);
        }

    }
}
