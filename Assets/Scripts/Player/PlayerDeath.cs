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
        _roundData = GameObject.Find(Tags.ROUNDDATA).GetComponent<RoundData>();
    }

    void OnEnable()
    {
        _isActive = true;
    }

	void Kill()
    {
        if (_isActive)
        {
            StartCoroutine(DeathAnimation());
            _isActive = false;            
        }
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(_deathDelay);
        _roundData.Remove(this.gameObject);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}
