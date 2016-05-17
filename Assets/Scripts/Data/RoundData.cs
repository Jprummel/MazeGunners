using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundData : MonoBehaviour {

    [SerializeField]private List<GameObject> _players;
    [SerializeField]private Text _RoundEndText;

	// Use this for initialization
	void Start () {
        _players = new List<GameObject>();

        RoundStart();

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            _players.Add(player);
        }
	}

    public void Remove(GameObject player)
    {
        _players.Remove(player);
        if (_players.Count == 1)
        {
            RoundEnd();
            StartCoroutine(GoToNextRound(1.5f));
        }
    }

    void RoundStart()
    {
        _players.Clear();

        if (GameObject.Find("Player 1") && GameObject.Find("Player 2") != null)
        {
            _players.Add(GameObject.Find("Player 1"));
            _players.Add(GameObject.Find("Player 2"));
        }
        
        if (GameObject.Find("Player 3") && GameObject.Find("Player 4") != null)
        {
            _players.Add(GameObject.Find("Player 3"));
            _players.Add(GameObject.Find("Player 4"));
        }
    }

    void RoundEnd()
    {
        _RoundEndText.text = _players[0].name + " Wins!";
    }

    IEnumerator GoToNextRound(float waitTime)
    {
        _RoundEndText.text = _players[0].name + " Wins!";        
        yield return new WaitForSeconds(waitTime);
        _RoundEndText.text = "Get ready for the next round";
        yield return new WaitForSeconds(waitTime);
        _RoundEndText.text = "";
        RoundStart();
    }
}
