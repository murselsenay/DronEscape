using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        SignIn();
	}
	void SignIn()
    {
        Social.localUser.Authenticate(success => { });
    }
   
    #region LeaderBoards
    public static void AddScoreToLeaderboard(string leaderboardId,long score)
    {
        Social.ReportScore(score, "CgkInI3Cx6MKEAIQAg", success => { });
    }
    public static void ShowLeaderboardsUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkInI3Cx6MKEAIQAg");
    }
    #endregion /LeaderBoards
}
