using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Vector2 offset = mesh.material.mainTextureOffset;
        offset.y += Time.deltaTime * scrollSpeed;
        mesh.material.mainTextureOffset = offset;
    }
}