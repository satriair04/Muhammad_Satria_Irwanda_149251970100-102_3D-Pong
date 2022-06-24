using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script masih belum jadi
public class PointManager : MonoBehaviour
{
    public int loseConditionPoint;
    public List<PointController> playerList;
    public UIManager uiManager;

    //Method pertama yang bakal sering dipanggil
    public void UpdatePlayer(PointController pointZone)
    {
        //Cek PointController yang mendapatkan point bola masuk;
        try
        {
            int playerIndex = playerList.FindIndex(search => search.Equals(pointZone));
            PlayerPointChecker(playerIndex);
        }
        catch (Exception error)
        {
            //Pakai try-catch untuk mengantisipasi 2 bola yang masuk bersamaan
            Debug.Log(error.Message);
        }
        
    }

    private void PlayerPointChecker(int playerIndex)
    {
        //Jika sudah ada satu pemain yg bertahan; Hentikan proses penghapusan player
        if (playerList.Count == 1)
        {
            return;
        }
        //Cek kondisi kalah pemain yang kebobolan
        if (playerList[playerIndex].totalPoint >= loseConditionPoint)
        {
            playerList[playerIndex].PlayerLose();
            RemovePlayer(playerList[playerIndex]);
            WinConditionChecker();
        }
    }
    public void RemovePlayer(PointController loser)
    {
        playerList.Remove(loser);
    }

    public void WinConditionChecker()
    {
        //Cek isi playerList apakah sisa 1
        if (playerList.Count != 1)
        {
            return;
        }
        //Pemain terakhir akan menempati index ini
        GameOver(playerList[0]);
    }

    //Method penutup sesi permainan
    public void GameOver(PointController winner)
    {
        uiManager.ShowGameOverPanel(winner.playerName);
        Debug.Log("SELAMAT " + winner.playerName + " BERHASIL SURVIVE!");
    } 
}


