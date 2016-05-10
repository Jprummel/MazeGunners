using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private GameObject _transparantWall;
    private ObjectPool _objectPoolScript;

    void Start()
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.OBJECTPOOL).GetComponent<ObjectPool>();
    }

    void ClearWall()
    {
        gameObject.layer = 8;
        _transparantWall = ObjectPool.instance.GetObjectForType(Tags.TRANSPARANTWALL, false);
        _transparantWall.transform.position = transform.position;
    }

    void OpaqueWall()
    {
        gameObject.layer = 0;
        _objectPoolScript.PoolObject(_transparantWall);
    }
}
