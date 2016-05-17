using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    private RoundData _roundData;
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
    }

    void OnEnable()
    {
        _isActive = true;
    }

	public void Kill()
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
        yield return new WaitForSeconds(_deathDelay);
        _roundData.Remove(this.gameObject);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}
