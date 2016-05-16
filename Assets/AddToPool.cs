using UnityEngine;
using System.Collections;

public class AddToPool : MonoBehaviour {
	private ObjectPool objectpool;
	// Use this for initialization
	void Start () {
		objectpool = GameObject.FindWithTag(Tags.OBJECTPOOL).GetComponent<ObjectPool>();
	}

	public void PoolPlayer(){
		objectpool.PoolObject (this.gameObject);
	}
}
