using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explodeScrypt : MonoBehaviour
{
    public float health = 3;
    private Vector3 randomspeed;
    Rigidbody rb;
    private void Start()
    {
        randomspeed = new Vector3(Random.Range(0.1f, 1000), Random.Range(0.1f, 1000), Random.Range(0.1f, 1000));
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true;
    }


    public void KMS()
    {
        rb.isKinematic = false;
        rb.velocity = new Vector3();
    }
}
