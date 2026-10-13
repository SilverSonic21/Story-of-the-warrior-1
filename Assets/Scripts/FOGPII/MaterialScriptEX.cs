using System;
using UnityEngine;

public class MaterialScriptEX : MonoBehaviour
{

    public float speed = 0;
    private Renderer renderer;
    private Material material;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    void Update()
    {
        material.SetFloat("_Speed", speed);
    }
}
