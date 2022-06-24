using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script dengan gaya Pak Luhut; Secara fungsi udah oke tetapi ga enak dipandang
public class PointController : MonoBehaviour
{
    public string playerName;
    public PaddleController playerPaddle;
    public PointManager pointManager;
    public SpawnManager spawnManager;
    public int totalPoint = 0;
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text playerPointText;

    private void Start()
    {
        playerNameText.text = playerName;
        playerPointText.text = totalPoint.ToString();
    }

    public void PlayerLose()
    {
        //Bagian ini dieksekusi ketika pemain mengalami kekalahan sesuai max score pada manager;
        //PointManager akan menjadi eksekutor method ini pada suatu PointController;
        playerPointText.text = "OUT!";
        GetComponent<Collider>().isTrigger = false;
        GetComponent<MeshRenderer>().enabled = true;
        playerPaddle.gameObject.SetActive(false);
        //Debug.Log("Player " + gameObject.name + " sudah KALAH!");
    }

    private void BallEscaped()
    {
        totalPoint += 1;
        playerPointText.text = totalPoint.ToString();
        pointManager.UpdatePlayer(this);
        Debug.Log("Method BallEscape pada game object " + gameObject.name + " sudah dijalankan");
    }

    private void OnTriggerExit(Collider other)
    {
        //Ketika sesuatu masuk lalu melewati Trigger; Cek tag object tersebut; Jalankan method
        if(other.CompareTag("PlayableBall"))
        {
            spawnManager.UnregisterPlayableBall(other.gameObject);
            BallEscaped();
        }
    }
}


