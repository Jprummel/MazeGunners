using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelData : MonoBehaviour {

    [SerializeField]private Slider      _lengthSlider;
    [SerializeField]private Slider      _widthSlider;
    [SerializeField]private GameObject  _multiplayerPanel;
    
    private bool singleplayerMode;
    public  bool singleplayer
    {
        get {return singleplayerMode;}
    }
    
    private bool multiplayerMode;
    public  bool multiplayer
    {
        get { return multiplayerMode; }
    }
    
    private float widthValue;
    public  float mapWidth
    {
        get {return widthValue;}
    }

    private float lengthValue;
    public  float mapLength
    {
        get { return lengthValue;}
    }
    
    private int players;
    public  int GetPlayers
    {
        get {return players;}
    }

    void Start()
    {
        widthValue = _widthSlider.value;
        lengthValue = _lengthSlider.value;
    }

    void Update()
    {
        Debug.Log(multiplayerMode);
        if (_multiplayerPanel.activeSelf == true)
        {
            multiplayerMode = true;
            singleplayerMode = false;
        }
        else
        {
            multiplayerMode = false;
            singleplayerMode = true;
        }
    }

    public void SetMapWidth()
    {
        if (multiplayerMode)
        {
            widthValue = _widthSlider.value;
            Debug.Log(widthValue + "Width");
        }
    }

    public void SetMapLength()
    {
        if (multiplayerMode)
        {
            lengthValue = _lengthSlider.value;
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
