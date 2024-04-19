using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public event EventHandler OnUsed;

    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material greenDarkMaterial;

    private MeshRenderer buttonMeshRenderer;
    private Transform buttonTransform;
    private bool canUseButton;

    private void Awake()
    {
        buttonTransform = transform.Find("Button");
        buttonMeshRenderer = buttonTransform.GetComponent<MeshRenderer>();
        canUseButton = true;
    }

    private void Start()
    {
        ResetButton();
    }

    public bool CanUseButton()
    {
        return canUseButton;
    }

    public void UseButton()
    {
        if (canUseButton) 
        {
            buttonMeshRenderer.material = greenDarkMaterial;
            buttonTransform.localScale = new Vector3(.5f, .2f, .5f);
            canUseButton = false;

            OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ResetButton()
    {
        buttonMeshRenderer.material = greenMaterial;
        buttonTransform.localScale = new Vector3(.5f, .5f, .5f);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, UnityEngine.Random.Range(-2f, +1f));
        canUseButton = true;
    }
}
