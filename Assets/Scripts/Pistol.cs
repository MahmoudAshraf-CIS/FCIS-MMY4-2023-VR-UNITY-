using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Pistol : MonoBehaviour
{

    private bool pistolInHand = false;
    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean trigger;

    public bool PistolInHand { get => pistolInHand; set => pistolInHand = value; }


    public GameObject bulletPrefab;
    public GameObject pistolParrel;
    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(hand) && PistolInHand)
        {
            Debug.Log("Shoot");
            // instantiate a new bullet 
            GameObject newBullet = GameObject.Instantiate(bulletPrefab, pistolParrel.transform.position, pistolParrel.transform.rotation, null);

            // add force to move the bullet in the pistol forward direction 

            // new Bullet to be moved 
            // bullet rigidbody . addforce 
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            
            //if (rb != null)
            if (rb)
                rb.AddRelativeForce(0, 0, 20, ForceMode.Impulse);

        }
    }


    
}
