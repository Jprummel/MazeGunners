using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    private GameObject[] _players;

	// Use this for initialization
	void Start () {
	    _players = GameObject.FindGameObjectsWithTag("Player");
        //CreateScoreBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            GUI.TextField(new Rect(10, 10, 200, 20), "Player");
        }
    }

    void UpdateScoreBoard()
    {

    }
}
