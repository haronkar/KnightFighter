using UnityEngine;
using UnityEngine.UI
    ;
public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        int wave = WaveSpawner.waveIndex;
        score.text = wave.ToString();

        if (wave > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", wave);
            highScore.text = wave.ToString();
        }
    }
}
