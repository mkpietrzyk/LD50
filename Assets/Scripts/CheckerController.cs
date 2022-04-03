using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CheckerController : MonoBehaviour
{
    public TMP_InputField playerInputField;
    // public TextMeshProUGUI placeholder;
    public GameObjectVariable selectedBox;
    public StringVariable boxLabel;
    public StringVariable playerInput;
    public IntVariable score;
    public IntVariable misses;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            playerInputField.Select();
            playerInputField.ActivateInputField();
            var label = other.GetComponentInChildren<TextMeshPro>().text;
            // selectedBox.Value = other.GetComponent<GameObject>();
            boxLabel.Value = label.ToLower();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            if (boxLabel.Value == playerInput.Value)
            {
                var newScore = score.Value + 1;
                if (newScore % 5 == 0 && misses.Value > 1) misses.Value -= 1;
                score.Value = newScore;
            }
            else
            {
                misses.Value += 1;
            }
            boxLabel.Value = "awaiting parcel...";
            playerInput.Value = "";
            playerInputField.DeactivateInputField();
        }
    }
}