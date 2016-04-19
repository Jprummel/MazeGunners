using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiplayerOptionsHandler : MonoBehaviour {

    [SerializeField]private Slider _lengthSlider;
    [SerializeField]private Slider _widthSlider;
    public int players;
    public float widthValue;
    public float lengthValue;

    void Start()
    {
        widthValue = _widthSlider.value;
        lengthValue = _lengthSlider.value;
    }

    public void SetMapWidth()
    {
        widthValue = _widthSlider.value;
        Debug.Log(widthValue + "Width");
    }

    public void SetMapLength()
    {
        lengthValue = _lengthSlider.value;
        Debug.Log(lengthValue + "Length");
    }

    public void SetPlayers(int playerAmount)
    {
        players = playerAmount;
        Debug.Log(playerAmount);
        DontDestroyOnLoad(this);   
    }
}
