using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private MeshRenderer _meshRenderer;

	// Use this for initialization
	void Start () {
        _meshRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ClearWall()
    {
        _meshRenderer.enabled = false;
    }

    void OpaqueWall()
    {
        _meshRenderer.enabled = true;
    }
}
