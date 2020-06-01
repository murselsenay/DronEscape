using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBoardManager : MonoBehaviour {
    public static LBoardManager Instance { get; private set; }
    public static int Counter { get; private set; }

    int leaderBoardPoint;
	// Use this for initialization
	void Start () {
        Instance = this;
        leaderBoardPoint = PlayerPrefs.GetInt("highScore");
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_lider_listesi, leaderBoardPoint);
    }
	
	// Update is called once per frame
	public void IncrementCounter () {
        Counter++;
        LBoardUI.Instance.UpdatePointsText();

    }
    public void RestartGame()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_lider_listesi, Counter);
        Counter = 0;
        LBoardUI.Instance.UpdatePointsText();
    }
}
