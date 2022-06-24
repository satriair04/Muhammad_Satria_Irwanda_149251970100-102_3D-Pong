using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverPanel_playerName;
    
    public void ShowGameOverPanel(string playerName)
    {
        gameOverPanel.SetActive(true);
        gameOverPanel_playerName.text = playerName;
    }
}
