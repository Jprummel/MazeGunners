using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelData : MonoBehaviour {

    [SerializeField]private Slider      _lengthSlider;
    [SerializeField]private Slider      _widthSlider;
    [SerializeField]private GameObject  _multiplayerPanel;
    
	private bool singleplayerMode = false;
    public  bool singleplayer
    {
        get {return singleplayerMode;}
    }
    
	private bool multiplayerMode = false;
    public  bool multiplayer
    {
        get { return multiplayerMode; }
    }
    
    private int widthValue = 10;
    public  int mapWidth
    {
        get {return widthValue;}
    }

    private int lengthValue = 10;
    public  int mapLength
    {
        get { return lengthValue;}
    }
    
    private int players = 4;
    public  int GetPlayers
    {
        get {return players;}
    }

    void Start()
    {
		if (_widthSlider) {
			widthValue = Mathf.RoundToInt(_widthSlider.value);
			lengthValue = Mathf.RoundToInt(_lengthSlider.value);
		}
    }

    void Update()
    {
        //Debug.Log(multiplayerMode);
		if (_multiplayerPanel != null) {
			if (_multiplayerPanel.activeSelf == true) {
				multiplayerMode = true;
				singleplayerMode = false;
			} else {
				multiplayerMode = false;
				singleplayerMode = true;
			}
		}
    }

    public void SetMapWidth()
    {
        if (multiplayerMode)
        {
			widthValue =  Mathf.RoundToInt(_widthSlider.value);
            Debug.Log(widthValue + "Width");
        }
    }

    public void SetMapLength()
    {
        if (multiplayerMode)
        {
			lengthValue = Mathf.RoundToInt (_lengthSlider.value);
            Debug.Log(lengthValue + "Length");
        }
    }

    public void SetPlayers(int playerAmount)
    {
        if (multiplayerMode)
        {
            players = playerAmount;
            Debug.Log(playerAmount);
            DontDestroyOnLoad(this);
        }   
    }
}
