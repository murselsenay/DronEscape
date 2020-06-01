using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LBoardUI : MonoBehaviour {
    public static LBoardUI Instance { get; private set; }
    // Use this for initialization
    void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [SerializeField]
    private Text pointsTxt;

    public void GetPoint()
    {
        LBoardManager.Instance.IncrementCounter();
    }
    public void Restart()
    {
        LBoardManager.Instance.RestartGame();
    }
   public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }
    public void UpdatePointsText()
    {
        pointsTxt.text = LBoardManager.Counter.ToString();
    }
}
