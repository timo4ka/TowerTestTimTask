using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private MoneyManager moneyManager;

    #region Damage
    [Header("Damage")]
    [SerializeField] private int priceDamage = 1;
    [SerializeField] private int addDamageOnUpgrade = 1;
    [SerializeField] private int damage = 1;
    public int Damage => damage;
    public int PriceDamage => priceDamage;
    #endregion

    #region ShotSpeed
    [Header("ShotSpeed")]
    [SerializeField] private int priceShotSpeed = 1;
    [SerializeField] private float addShotSpeedOnUpgrade = -0.3f;
    [SerializeField] private float shotSpeed = 1;
    public float ShotSpeed => shotSpeed;
    public int PriceShotSpeed => priceShotSpeed;
    #endregion

    #region Radius
    [Header("Radius")]
    [SerializeField] private int priceRadius = 1;
    [SerializeField] private int addRadiusOnUpgrade = 1;
    [SerializeField] private int radius = 3;
    public int Radius => radius;
    public int PriceRadius => priceRadius;
    #endregion
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        moneyManager = FindObjectOfType<MoneyManager>();
        //damage = PlayerPrefs.GetInt(nameof(damage), damage);
        //shotSpeed = PlayerPrefs.GetFloat(nameof(shotSpeed), shotSpeed);
        //radius = PlayerPrefs.GetInt(nameof(radius), radius);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(nameof(damage), damage);
        PlayerPrefs.SetFloat(nameof(shotSpeed), shotSpeed);
        PlayerPrefs.SetInt(nameof(radius), radius);

    }

    public bool CanSpend(int value)
    {
        return moneyManager.CanSpend(value);
    }

    public void TryToUpgradeDamage()
    {

        if (moneyManager.CanSpend(priceDamage))
        {
            moneyManager.Spend(priceDamage);
            damage += addDamageOnUpgrade;
            //  PlayerPrefs.SetInt(nameof(damage), damage);
            EventManager.OnEvent(eEventType.UpdateParameter);
        }
    }

    public void TryToUpgradeShotSpeed()
    {

        if (moneyManager.CanSpend(priceShotSpeed))
        {
            moneyManager.Spend(priceShotSpeed);
            if (shotSpeed + addShotSpeedOnUpgrade < 0)
                return;

            shotSpeed += addShotSpeedOnUpgrade;
            //PlayerPrefs.SetFloat(nameof(shotSpeed), shotSpeed);
            EventManager.OnEvent(eEventType.UpdateParameter);
        }
    }
    public void TryToUpgradeRadius()
    {

        if (moneyManager.CanSpend(priceRadius))
        {
            moneyManager.Spend(priceRadius);
            radius += addRadiusOnUpgrade;
            //PlayerPrefs.SetInt(nameof(radius), radius);
            EventManager.OnEvent(eEventType.UpdateParameter);
        }
    }

}
