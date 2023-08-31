using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private Color originalColor;
    private Color hitColor = Color.gray;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void SetHitColor()
    {
        spriteRenderer.material.color = hitColor;
    }

    public void ResetColor()
    {
        spriteRenderer.material.color = originalColor;
    }
}
