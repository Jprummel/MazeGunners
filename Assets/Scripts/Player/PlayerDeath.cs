using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    private RoundData _roundData;
    private Animator _animator;
    private bool _isActive = true;
    public bool IsActive
    {
        get
        {
            return _isActive;
        }
    }
    private float _deathDelay = 1;

    void Start()
    {
		_roundData = GameObject.FindGameObjectWithTag(Tags.ROUNDDATA).GetComponent<RoundData>();
        _animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        _isActive = true;
    }

	public void Death()
    {
        if (_isActive)
        {
            StartCoroutine(DeathAnimation());
            _isActive = false;
        }
    }

	public void FastKill(){
		if (_isActive)
		{
			_isActive = false;            
			_roundData.Remove(this.gameObject);
			ObjectPool.instance.PoolObject(this.gameObject);
		}
	}

    IEnumerator DeathAnimation()
    {
        if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Idle"))
        {
            _animator.SetBool("isDying", true);
        }
        else
        {
            _animator.SetBool("isDying", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeRight"))
        {
            _animator.SetBool("rightToDie", true);
        }
        else
        {
            _animator.SetBool("rightToDie", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(2).IsName("StrafeLeft"))
        {
            _animator.SetBool("leftToDie", true);
        }
        else
        {
            _animator.SetBool("leftToDie", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingForward"))
        {
            _animator.SetBool("forwardToDie", true);
        }
        else
        {
            _animator.SetBool("forwardToDie", false);
        }

        if (_animator.GetCurrentAnimatorStateInfo(2).IsName("MovingBackward"))
        {
            _animator.SetBool("backwardToDie", true);
        }
        else
        {
            _animator.SetBool("backwardToDie", false);
        }

        yield return new WaitForSeconds(_deathDelay);
        _roundData.Remove(this.gameObject);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}
