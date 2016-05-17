using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundData : MonoBehaviour {

    [SerializeField]private List<GameObject> _players;
    [SerializeField]private Text _RoundEndText;
	private MazeGenerator _maze;
    private int _roundNumber;

	// Use this for initialization
	void Start () {
        _roundNumber = 1;
        _players = new List<GameObject>();
		_maze = GameObject.FindGameObjectWithTag (Tags.GENERATOR).GetComponent<MazeGenerator>();

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
            if (_roundNumber <= 4)
            {
                StartCoroutine(GoToNextRound(1.5f));
            }
            if (_roundNumber > 4)
            {
                StartCoroutine(FinalRound(1.5f));
            }
        }
    }

    void RoundStart()
    {
        _players.Clear();

        if (GameObject.Find(ObjectPoolNames.PLAYER1) && GameObject.Find(ObjectPoolNames.PLAYER2) != null)
        {
            _players.Add(GameObject.Find("Player 1"));
            _players.Add(GameObject.Find("Player 2"));
        }
        
        if (GameObject.Find(ObjectPoolNames.PLAYER3) && GameObject.Find(ObjectPoolNames.PLAYER4) != null)
        {
            _players.Add(GameObject.Find("Player 3"));
            _players.Add(GameObject.Find("Player 4"));
        }
    }

 

    IEnumerator GoToNextRound(float waitTime)
    {
        _roundNumber++;
        _RoundEndText.text = _players[0].name + " Wins!";        
        yield return new WaitForSeconds(waitTime);
        _RoundEndText.text = "Get ready for the next round";
        yield return new WaitForSeconds(waitTime);
        _RoundEndText.text = "";
		_maze.ReGenerate ();
        RoundStart();
    }

    IEnumerator FinalRound(float waitTime)
    {
        _RoundEndText.text = _players[0].name + "Wins the final round!"; 
        yield return new WaitForSeconds(waitTime);
        _RoundEndText.text = "Returning to menu in 3...";
        yield return new WaitForSeconds(1);
        _RoundEndText.text = "Returning to menu in 2...";
        yield return new WaitForSeconds(1);
        _RoundEndText.text = "Returning to menu in 1...";
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);

    }
}
