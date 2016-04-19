using UnityEngine;
using System.Collections;

public class OptionChecker : MonoBehaviour {

    private MultiplayerOptionsHandler _optionsHandler;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

	void Start () {
        _optionsHandler = GameObject.Find("MultiplayerOptionsHandler").GetComponent<MultiplayerOptionsHandler>();
        if(_optionsHandler.players == 2){
            player3.SetActive(false);
            player4.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
