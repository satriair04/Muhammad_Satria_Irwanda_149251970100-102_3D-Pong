using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float selfBallSpeed = 10;                //Abaikan; Speed bola bisa dicustom pada SpawnManager
    public bool usingManualBallDirection = false;   //Untuk debug, abaikan; Arah bola diatur berdasarkan titik spawnPoint pada masing-masing BallSpawner
    public Vector3 ballDirection;                   //Abaikan dong; 
    private Rigidbody rb3d;
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        if (usingManualBallDirection)
        {
            //Bola berjalan dengan kehendaknya sendiri mengikuti Vector3 global
            rb3d.AddForce((ballDirection.normalized * selfBallSpeed), ForceMode.Impulse);   
        }
            //AddForce melalui BallSpawner, Bola akan menjadi objek biasa yg diam ditempat
    }

    private void FixedUpdate()
    {
        //Diupdate terus menerus berdasarkan speed * situasi velocity bola
        
        rb3d.velocity = selfBallSpeed * (rb3d.velocity.normalized);     //MANTAB MANTUL, BOLANYA JADI KONSTAN SPEED

        
    }

    public void SetCustomSpeed(float value)
    {
        this.selfBallSpeed = value;
    }


}
