using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusUpgradeButton : BaseUpgradeButton
{
    protected override void Awake()
    {
        base.Awake();
        price = upgradeManager.PriceRadius;
    }
    protected override void TryUpgrade()
    {
        upgradeManager.TryToUpgradeRadius();
    }

    protected override void UpdateAvailability()
    {
        price = upgradeManager.PriceRadius;
        value.text =   upgradeManager.Radius.ToString();
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
