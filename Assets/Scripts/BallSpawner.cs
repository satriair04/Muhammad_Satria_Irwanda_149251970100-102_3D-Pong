using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Transform spawnPoint;        //Titik muncul bola, Arah bola akan mengacu pada sumbu X positif dari titik ini (Vector3.right)

    public void BallSpawn(GameObject ball, float customBallSpeed, bool overrideBallSpeed)
    {
        //Instantiate berdasarkan game object yg diberi oleh manager; Instantiate
        GameObject spawnedBall = Instantiate(ball, spawnPoint.position, spawnPoint.rotation);

        if (overrideBallSpeed)
        {
            //Ubah dulu speed internal bola jika override speed = true
            spawnedBall.GetComponent<BallController>().SetCustomSpeed(customBallSpeed);
        }

        //Berikan gaya dorong pada bola berdasarkan titik spawnPoint-nya
        spawnedBall.GetComponent<Rigidbody>().AddForce((spawnPoint.right.normalized * spawnedBall.GetComponent<BallController>().selfBallSpeed), ForceMode.Impulse);
        
        spawnedBall.SetActive(true);
        BallRegister(spawnedBall);
        Debug.Log("Bola telah ter-spawn pada: " + gameObject.name.ToString());
    }

    
    public void RandomSpawnRotation(float angleRange)
    {
        //Membuat rotasi lokal pada sumbu Y secara acak agar bola yg keluar dari sumbu X lokal tidak gitu-gitu aja
        Vector3 spawnPointRandomize = spawnPoint.localRotation.eulerAngles;     //Ambil dulu sudut euler-nya
        spawnPointRandomize.y = Random.Range(angleRange, -angleRange);          //Modif nilai Y
        spawnPoint.localRotation = Quaternion.Euler(spawnPointRandomize);       //Ubah rotasi lokal dari spawnPoint
    }

    private void BallRegister(GameObject ballToAdd)
    {
        spawnManager.RegisterPlayableBall(ballToAdd);
    }
}
