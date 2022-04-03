using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    public StringVariable uiState;
    public StringConstant uiElement;

    public void SetVisibility()
    {
        if (uiState.Value == uiElement.Value)
        {
            SetChildrenActive(true);
        }
        else
        {
            SetChildrenActive(false);
        }
    }

    private void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}