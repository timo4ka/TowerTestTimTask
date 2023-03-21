using JoshH.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUpgradeButton : BaseButton
{
    [SerializeField] protected Text value;
    [SerializeField] protected Text priceText;
    protected UIGradient bg;
    protected UpgradeManager upgradeManager;
    protected Color baseColor1;
    protected Color baseColor2;
    protected Color negativeColor1 = Color.gray;
    protected Color negativeColor2 = Color.black;
    protected int price;

    protected override void Awake()
    {
        base.Awake();
        bg = GetComponent<UIGradient>();
        baseColor1 = bg.LinearColor1;
        baseColor2 = bg.LinearColor2;
        upgradeManager = FindObjectOfType<UpgradeManager>();
        EventManager.Subscribe(eEventType.UpdateParameter, (e) => UpdateAvailability());
        UpdateAvailability();
    }
    protected override void OnClick()
    {
        TryUpgrade();
    }

    protected abstract void TryUpgrade();
    protected abstract void UpdateAvailability();
}
