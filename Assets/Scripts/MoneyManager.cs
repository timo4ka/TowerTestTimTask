using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int money = 0;

    private void OnEnable()
    {
        //  DontDestroyOnLoad(this.gameObject);
        //  money = PlayerPrefs.GetInt(nameof(money), 0);
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        EventManager.OnEvent(eEventType.UpdateMoneytUI, money);
        EventManager.OnEvent(eEventType.UpdateParameter);

        // PlayerPrefs.SetInt(nameof(money), money);
    }

    public void Spend(int amount)
    {
        if (amount <= money)
        {
            money -= amount;
            EventManager.OnEvent(eEventType.UpdateMoneytUI, money);
            EventManager.OnEvent(eEventType.UpdateParameter);

            //   PlayerPrefs.SetInt(nameof(money), money);

        }
        else
        {

            Debug.LogError("No money");
        }
    }

    public bool CanSpend(int amount)
    {
        return amount <= money;
    }
}
