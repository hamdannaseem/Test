using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text[] LeaderNames, LeaderScores, Achievements;
    string ln = "LeaderName_", ls = "LeaderScore_", ach = "Achievement_";
    void Start()
    {
        FetchData();
    }
    void FetchData()
    {
        for (int i = 1; i < 6; i++)
        {
            LeaderNames[i - 1].text = PlayerPrefs.GetString((ln + i), "Null");
            LeaderScores[i - 1].text = PlayerPrefs.GetInt((ls + i), 0).ToString();
            if (PlayerPrefs.GetInt(ach + i) == 1)
            {
                Achievements[i - 1].color = new Color(255f / 255f, 215f / 255f, 0f / 255f);
            }
            else
            {
                Achievements[i - 1].color = new Color(50f / 255f, 50f / 255f, 50f / 255f);
            }
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetString((ln + i), "Null");
            PlayerPrefs.SetInt((ls + i), 0);
            PlayerPrefs.SetInt(ach + i, 0);
        }
        FetchData();
    }
}
