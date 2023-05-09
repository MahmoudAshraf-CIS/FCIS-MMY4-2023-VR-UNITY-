using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class Enemy : MonoBehaviour
{
    public GameObject Player;
    float speed = 1;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("point");
        //Player = GameObject.FindObjectOfType<Player>().gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(Player.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y ,0) ;

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // not recommended to move with transform
    }

    private void FixedUpdate()
    {
        // if the distance is greater than 2 miter 
        if(Vector3.Distance(this.transform.position , Player.transform.position) > 2)
        {
            //Debug.Log("adding force");
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        else
        {
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            // todo - remove score
            ScoreManager.Instance.RemoveScore(1);
            DestroyImmediate(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        if(collision.transform.tag == "enemy")
        {
            Debug.Log("Collided with " + collision.gameObject.name);
            Destroy(this.gameObject);
        }
        else if(collision.transform.tag == "Bullet")
        {
            // add score
            ScoreManager.Instance.AddScore(1);
            Destroy(this.gameObject);
        }
    }
}
