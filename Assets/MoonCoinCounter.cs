using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoonCoinCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int currentScore = 0;

    private void Update()
    {
        counter.text = currentScore.ToString();    
    }
}
