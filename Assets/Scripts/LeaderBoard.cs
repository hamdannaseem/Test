using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text[] LeaderNames, LeaderScores;
    void Start()
    {
        FetchData();
    }
    void FetchData()
    {
        string ln = "LeaderName_", ls = "LeaderScore_";
        for (int i = 1; i < 6; i++)
        {
            LeaderNames[i - 1].text = PlayerPrefs.GetString((ln + i), "Null");
            LeaderScores[i - 1].text = PlayerPrefs.GetInt((ls + i), 0).ToString();
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        string ln = "LeaderName_", ls = "LeaderScore_";
        for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetString((ln + i), "Null");
            PlayerPrefs.SetInt((ls + i), 0);
        }
        FetchData();
    }
}
