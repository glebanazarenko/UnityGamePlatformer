using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public static int Coin;
    Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    private void Update() {
        text.text = Coin.ToString();
    }
}
