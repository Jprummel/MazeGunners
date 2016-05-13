using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    private ObjectPool _objectPoolScript;
    [SerializeField]private float _destroyTime;

	void OnEnable () 
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.OBJECTPOOL).GetComponent<ObjectPool>();
        StartCoroutine(DestroyDelay());
	}

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_destroyTime);
        _objectPoolScript.PoolObject(this.gameObject);
    }
}
