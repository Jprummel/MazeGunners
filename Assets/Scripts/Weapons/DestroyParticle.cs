using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

    private ParticleSystem _particleSystem;

    private int _particleCount;
    
	void OnEnable () 
    {
        _particleSystem = transform.GetComponent<ParticleSystem>();
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
            ObjectPool.instance.PoolObject(this.gameObject);
        }
    }
}
