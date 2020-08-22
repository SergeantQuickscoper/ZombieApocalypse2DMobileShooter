using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  public float RotationOffset = 0f; // The Offset to be added to the RotationZ
  public Transform firePoint;
  public Transform bullet;
  public float fireRate;
  float timeToFire = 0; 

    // Update is called once per frame
    void Update()
    {
        // Calculates the difference between the Mouse Pointer position and Arm Position
        Vector3 Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Normalizes the Difference so that the sum of the three values equals 1. The values still
        Difference.Normalize();

        // Calculates the vector from the 0,0 point to the Difference point and then converts that into an angle. Rad2Deg converts the angle from radians to degrees
        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

        // Applies the rotation to the arm
        transform.rotation = Quaternion.Euler(0f, 0f, RotationZ + RotationOffset);

          // Update is called once per frame.
   
        if (fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    

    void Shoot()
    {
       Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
