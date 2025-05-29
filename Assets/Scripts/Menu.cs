using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject NameWindow, NameWarning, EndUI, AchievementsUI;
    public Text Name;
    public Button PlayButton, QuitButton;
    public void Play()
    {
        if (Name.text == "")
        {
            NameWarning.SetActive(true);
            return;
        }
        PlayerPrefs.SetString("CurrentPlayer", Name.text);
        SceneManager.LoadScene("Game");
    }
    public void Cancel()
    {
        Name.text = "";
        NameWarning.SetActive(false);
        NameWindow.SetActive(false);
        PlayButton.interactable = true;
        QuitButton.interactable = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SetName()
    {
        NameWindow.SetActive(true);
        PlayButton.interactable = false;
        QuitButton.interactable = false;
    }
    public void MainMenu()
    {
        PlayerMovement.pm.Speed = 10;
        PlayerMovement.GameOver = false;
        SceneManager.LoadScene("MainMenu");
        EndUI.SetActive(false);
    }
    public void Achievements(){
        if(AchievementsUI.activeSelf){
            AchievementsUI.SetActive(false);
        }else{
            AchievementsUI.SetActive(true);
        }
    }
}
