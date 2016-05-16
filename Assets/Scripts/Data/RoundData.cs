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
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            _players.Add(player);
        }

        Debug.Log(_players);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Remove(GameObject player)
    {
        _players.Remove(player);
        Debug.Log(_players[0].name);
        if (_players.Count == 1)
        {
            RoundEnd();
            Debug.Log(_players[0].name);
        }
    }

    void RoundEnd()
    {
        _RoundEndText.text = _players[0].name + " Wins!";
    }

    IEnumerator GoToNextRound(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
    }
}
