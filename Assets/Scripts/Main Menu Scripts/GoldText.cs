using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    TextMeshProUGUI _goldText;

    private void Awake()
    {
        if(_goldText == null)
            _goldText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _goldText.text = "GOLD: " + PlayerProfile.Gold.ToString();
    }
}
