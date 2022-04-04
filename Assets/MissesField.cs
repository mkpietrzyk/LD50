using TMPro;
using UnityEngine;

public class MissesField : MonoBehaviour
{
    public void UpdateScore(int misses)
    {
        switch (misses)
        {
            case 1: GetComponent<TextMeshProUGUI>().text = "X";
                break;
            case 2: GetComponent<TextMeshProUGUI>().text = "XX";
                break;
            case 3: GetComponent<TextMeshProUGUI>().text = "XXX";
                break;
            case 4: GetComponent<TextMeshProUGUI>().text = "XXXX";
                break;
            default:
                GetComponent<TextMeshProUGUI>().text = "";
                break;
        }
    }
}