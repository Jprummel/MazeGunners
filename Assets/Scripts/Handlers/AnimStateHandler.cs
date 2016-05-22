using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour {
    
	public static Animator _playerAnimator;
	public static Animator _viewModelAnimator;

    void Start()
    {
		if (_viewModelAnimator == null) {
			_viewModelAnimator = this.transform.Find("PlayerContainer/Camera/Viewmodel").GetComponent<Animator>();
			_playerAnimator = this.transform.Find("PlayerContainer/Heavyrat").GetComponent<Animator>();
		}
    }

    public static void Idle()
    {
        _playerAnimator.Play("Idle");
    }

    public static void ViewState(int whichState)
    {
        _viewModelAnimator.SetInteger("ViewState",whichState);
    }

    public static void AnimStateOverride(int whichState)//Sets the animation state for the Top Layer (Attack and such)
    {
        _playerAnimator.GetLayerName(1);
        _playerAnimator.SetInteger("OverrideState", whichState);
    }

    public static void AnimStateGeneral(int whichState)//Sets the animation state for general animations (Walking, idles , camera/enviroment)
    {
        _playerAnimator.GetLayerName(2);
        _playerAnimator.SetInteger("GeneralState", whichState);
    }    
}
