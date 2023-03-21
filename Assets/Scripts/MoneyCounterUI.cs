using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounterUI : MonoBehaviour
{
    private Text text;
    private void OnEnable()
    {
        text = GetComponentInChildren<Text>();
        EventManager.Subscribe(eEventType.UpdateMoneytUI, (e) => updateUi((int)e));
        updateUi(FindObjectOfType<MoneyManager>().GetMoney());
    }

    private void updateUi(int value)
    {
        text.text = value.ToString();
    }
}
