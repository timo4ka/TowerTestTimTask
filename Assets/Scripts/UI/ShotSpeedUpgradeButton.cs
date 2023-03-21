using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeedUpgradeButton : BaseUpgradeButton
{
    protected override void Awake()
    {
        base.Awake();
        price = upgradeManager.PriceShotSpeed;
    }
    protected override void TryUpgrade()
    {
        upgradeManager.TryToUpgradeShotSpeed();
    }

    protected override void UpdateAvailability()
    {
        price = upgradeManager.PriceShotSpeed;
        value.text =   upgradeManager.ShotSpeed.ToString();
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
