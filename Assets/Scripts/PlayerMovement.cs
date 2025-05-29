using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement pm;
    public float Speed, TrackSwitchSpeed, TrackDistance;
    int Track = 0;
    float TargetTrack = 0;
    public static int Score = 0;
    public static bool GameOver = false;
    public Text ScoreUI, WinResult, AchievementScore;
    public GameObject EndUI, Achievement;
    bool hasEnded = false;
    int[] achievements = { 75, 125, 250, 500, 1000 };
    int targetAchievement;
    void Start()
    {
        pm = this;
        Debug.Log(PlayerPrefs.GetString("CurrentPlayer"));
        bool hasEnded = false;
        targetAchievement = 1;
    }
    void Update()
    {
        if (GameOver)
        {
            return;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        if (Track != -1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            TargetTrack -= TrackDistance;
            Track--;
        }
        if (Track != 1 && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            TargetTrack += TrackDistance;
            Track++;
        }
        if (transform.position.x != TargetTrack)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(TargetTrack, transform.position.y, transform.position.z), TrackSwitchSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            ScoreUI.text = "Score:" + (++Score);
            if (Score == achievements[targetAchievement - 1])
            {
                string ach = "Achievement_";
                if (PlayerPrefs.GetInt(ach + targetAchievement) == 0)
                {
                    PlayerPrefs.SetInt(ach + targetAchievement, 1);
                    Debug.Log("Achievement Unlocked!");
                    AchievementScore.text = achievements[targetAchievement - 1] + " GOLD";
                    StartCoroutine("AchievementUI");
                }
                targetAchievement++;
            }
        }
        if (collision.collider.tag == "Obstacle")
        {
            Speed = 0;
            GameOver = true;
            EndGame();
        }
    }
    IEnumerator AchievementUI()
    {
        Achievement.SetActive(true);
        yield return new WaitForSeconds(3);
        Achievement.SetActive(false);
    }
    void EndGame()
    {
        if (hasEnded) { return; }
        hasEnded = true;
        int i = 1;
        for (i = 1; i < 6; i++)
        {
            if (Score > PlayerPrefs.GetInt(("LeaderScore_" + i), 0))
            {
                break;
            }
        }
        Debug.Log(i);
        if (i > 5)
        {
            WinResult.text = "You didn't make it to leaderboard";
            WinResult.color = Color.red;
        }
        else
        {
            EndUI.SetActive(true);
            WinResult.text = "You made it to leaderboard #" + (i);
            WinResult.color = Color.green;
            for (int j = 5; j > i; j--)
            {
                PlayerPrefs.SetInt(("LeaderScore_" + j), PlayerPrefs.GetInt("LeaderScore_" + (j - 1), 0));
                PlayerPrefs.SetString(("LeaderName_" + j), PlayerPrefs.GetString("LeaderName_" + (j - 1), "Null"));
            }
            PlayerPrefs.SetInt(("LeaderScore_" + i), Score);
            PlayerPrefs.SetString(("LeaderName_" + i), PlayerPrefs.GetString("CurrentPlayer"));
        }
        PlayerPrefs.Save();
        Score = 0;
        targetAchievement = 1;
    }

}