using TMPro;
using UnityEngine;

public class ScoreField : MonoBehaviour
{
    public void UpdateScore(int score)
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString("D4");
    }
}