using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgradeButton : BaseUpgradeButton
{
    protected override void Awake()
    {
        base.Awake();
        price = upgradeManager.PriceDamage;
    }
    protected override void TryUpgrade()
    {
        upgradeManager.TryToUpgradeDamage();
    }

    protected override void UpdateAvailability()
    {
        price = upgradeManager.PriceDamage;
        value.text = upgradeManager.Damage.ToString();
        priceText.text = price.ToString();
        if (upgradeManager.CanSpend(price))
        {
            bg.LinearColor1 = baseColor1;
            bg.LinearColor2 = baseColor2;
        }
        else
        {
            bg.LinearColor1 = negativeColor1;
            bg.LinearColor2 = negativeColor2;
        }
    }
}
