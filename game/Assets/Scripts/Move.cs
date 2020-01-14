using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource auSo;
    public float speed;
    public float tilt;
    public Boundary br;
    public GameObject shot;
    public Transform shotSpawn;
    public float nextFire;
    public float fireRate;


     void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            auSo = GetComponent<AudioSource>();
            auSo.Play();

        }
    }

    void FixedUpdate()
    {

        rb = GetComponent<Rigidbody>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = move * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, br.xMin, br.xMax), 0.0f, Mathf.Clamp(rb.position.z, br.zMin, br.zMax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}