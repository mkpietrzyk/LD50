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
    public TextMeshProUGUI correct;
    public TextMeshProUGUI incorrect;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            if (boxLabel.Value == playerInput.Value)
            {
                correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, 1f);
                incorrect.color = new Color(incorrect.color.r, incorrect.color.g, incorrect.color.b, 0.5f);
            }
            else
            {
                incorrect.color = new Color(incorrect.color.r, incorrect.color.g, incorrect.color.b, 1f);
                correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, 0.5f);
            }
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
            playerInputField.text = "";
            playerInputField.DeactivateInputField();
            correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, 0.5f);
            incorrect.color = new Color(incorrect.color.r, incorrect.color.g, incorrect.color.b, 0.5f);
        }
    }
}