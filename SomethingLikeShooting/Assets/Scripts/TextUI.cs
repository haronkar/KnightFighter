using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Text pointText;
    public Text waveText;
    public Text killsText;
    public Text healthText;

    private void Start()
    {
        Time.timeScale = 1f;
        WaveSpawner.enemieskilled = 0;
    }
    void Update()
    {
        pointText.text = "Points : " + Player_Stats.Points.ToString();
        waveText.text = "Wave : " + WaveSpawner.waveIndex.ToString();
        killsText.text = WaveSpawner.enemieskilled.ToString();
        healthText.text = Player_Stats.health.ToString();
    }
}
