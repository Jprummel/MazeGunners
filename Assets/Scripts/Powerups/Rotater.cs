using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour
{
    private float _rotateAmount = 1f;

    void Update () 
    {
        transform.Rotate(Vector3.up * _rotateAmount);
	}
}
