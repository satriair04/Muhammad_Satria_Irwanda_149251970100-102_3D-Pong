using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerUI : MonoBehaviour
{
    private Text localText;
    void Start()
    {
        localText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        localText.text = Time.deltaTime.ToString();
    }
}
