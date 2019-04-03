using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject htpMenu;
    public GameObject rulesMenu;
    public Text highScore;

    public void Start()
    {
        mainMenu.SetActive(true);
        htpMenu.SetActive(false);
        rulesMenu.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void PLayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void HTPMemu()
    {
        mainMenu.SetActive(false);
        htpMenu.SetActive(true);
        rulesMenu.SetActive(false);
    }

    public void RulesMenu()
    {
        mainMenu.SetActive(false);
        htpMenu.SetActive(false);
        rulesMenu.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }


}
