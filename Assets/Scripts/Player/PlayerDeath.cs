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
        AnimStateHandler.AnimStateGeneral(5);
        yield return new WaitForSeconds(_deathDelay);
        _roundData.Remove(this.gameObject);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}
