using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

    private ObjectPool _objectPoolScript;
    private ParticleSystem _particleSystem;

    private int _particleCount;
    

	void OnEnable () 
    {
        _particleSystem = transform.GetComponent<ParticleSystem>();
        _objectPoolScript = GameObject.FindWithTag(Tags.OBJECTPOOL).GetComponent<ObjectPool>();
        _particleCount = _particleSystem.particleCount;
	}

    void Update()
    {
        DisableParticle();
    }

    void DisableParticle()
    {
        if(_particleCount <= 0)
        {
            _objectPoolScript.PoolObject(this.gameObject);
        }
    }
}
