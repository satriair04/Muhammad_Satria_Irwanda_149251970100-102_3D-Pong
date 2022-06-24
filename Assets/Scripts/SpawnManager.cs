using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ballReference;
    public int ballSpawnLimit;
    public float ballSpawnInterval;
    public bool overrideBallSpeed = false;
    public float customBallSpeed = 10;      //Ubah suka hati
    public List<GameObject> playableBall;
    public bool usingRandomSpawnAngle = false;
    public float customSpawnerAngle = 30f;
    public List<GameObject> ballSpawners;
    private float timer;

    // Start is called before the first frame update
    
    void Start()
    {
        playableBall = new List<GameObject>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ballSpawnInterval)
        {
            SpawnChecker();
            timer = 0f;
        }
    }

    private void SpawnChecker()
    {
        //Cek pra-syarat; Apakah bola sudah mencapai batas
        if (playableBall.Count >= ballSpawnLimit)
        {
            return;
        }
        

        Debug.Log("Salah satu spawner telah dipanggil");
        //Pilih dulu spawnernya secara acak; Kemudian panggil fungsi spawn-bola pada spawnernya
        int randomValue = Random.Range(0, ballSpawners.Count);
        if (usingRandomSpawnAngle)
        {
            ballSpawners[randomValue].GetComponent<BallSpawner>().RandomSpawnRotation(customSpawnerAngle);
        }
        ballSpawners[randomValue].GetComponent<BallSpawner>().BallSpawn(ballReference, customBallSpeed, overrideBallSpeed);

        //Reset timer pada manager kembali ke 0
        timer = 0f;
        
    }

    public void UnregisterPlayableBall(GameObject ballToRemove)
    { 
        playableBall.Remove(ballToRemove);
        Destroy(ballToRemove);
    }

    public void RegisterPlayableBall(GameObject ballToAdd)
    {
        playableBall.Add(ballToAdd);
    }

    private void UnregisterAllBall()
    {
        while (playableBall.Count > 0)
        {
            UnregisterPlayableBall(playableBall[0]);
        }
    }
}
