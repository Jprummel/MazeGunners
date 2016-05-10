using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private float _maxLifeTime;
    [SerializeField]private float _dmg = 1f;
    private float _lifeTime;
    private ObjectPool _objectPoolScript;

    //[SerializeField]private GameObject _explosionPrefab;

    void Start()
    {
        _objectPoolScript = GameObject.FindWithTag(Tags.OBJECTPOOL).GetComponent<ObjectPool>();
    }

    void OnEnable()
    {
        StartCoroutine(DestructionDelay());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        /*float delta = Time.deltaTime;
        transform.Translate(Vector3.forward * _speed * delta);
        _lifeTime += delta;
        if (_lifeTime > _maxLifeTime)
        {
            Destroy(this.gameObject);
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("ApplyDamage", _dmg,SendMessageOptions.DontRequireReceiver);
            //Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
            //Destroy(this.gameObject);
        }
        _objectPoolScript.PoolObject(this.gameObject);
    }

    IEnumerator DestructionDelay()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        _objectPoolScript.PoolObject(this.gameObject);
        //Destroy(this.gameObject);
    }
}
