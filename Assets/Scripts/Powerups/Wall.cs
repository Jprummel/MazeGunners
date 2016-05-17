using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private GameObject _transparantWall;

    void ClearWall()
    {
        gameObject.layer = 8;
        _transparantWall = ObjectPool.instance.GetObjectForType(ObjectPoolNames.TRANSPARANTWALL, false);
        _transparantWall.transform.position = transform.position;
    }

    void OpaqueWall()
    {
        gameObject.layer = 0;
        ObjectPool.instance.PoolObject(_transparantWall);
    }
}
