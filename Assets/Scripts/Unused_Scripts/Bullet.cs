using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    /*[SerializeField]private float _speed;
    [SerializeField]private float _maxLifeTime;
    [SerializeField]private float _dmg = 1f;
    private float _lifeTime;

    //[SerializeField]private GameObject _explosionPrefab;

    void OnEnable()
    {
        StartCoroutine(DestructionDelay());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("ApplyDamage", _dmg,SendMessageOptions.DontRequireReceiver);
            GameObject hitEffect = ObjectPool.instance.GetObjectForType(ObjectPoolNames.HITEFFECT, false);
            hitEffect.transform.position = transform.position;
        }
        ObjectPool.instance.PoolObject(this.gameObject);
    }

    IEnumerator DestructionDelay()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        ObjectPool.instance.PoolObject(this.gameObject);
    }*/
}
