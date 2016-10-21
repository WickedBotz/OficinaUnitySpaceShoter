﻿using UnityEngine;
using System.Collections;

[System.Serializable]

public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource audioSource;
    public Boundary boundary;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public float speed;
    public float iniclinacao;
    

    public GameObject tiros;
    public Transform[] criaTiros;
   // public Transform shotSpawnLeft;
    public float fireRate;

    private float nextFire;

    void Update() {
        //Ao perceber que botao esquerdo do mouse for clicado, criar as balas no espaço.
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            foreach(var shotspawn in criaTiros) {
                Instantiate(tiros, shotspawn.position, shotspawn.rotation);
            }
           // Instantiate(tiros, shotSpawnRight.position, shotSpawnRight.rotation);      
           // Instantiate(tiros, shotSpawnLeft.position, shotSpawnLeft.rotation);
            audioSource.Play();
        }
    }


    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Velocidade da nave
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //Limite da caixa do espaço.
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        //Rotação da nave em movimento.
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -iniclinacao);
    }
}
