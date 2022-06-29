using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;

    [Header("Buttons")]
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;
    public Color upgradedButtonColor;
    public Color baseButtonColor;

    private Node target;
    
    public void SetTarget(Node _target)
    {
        target = _target;

        SetUpgradeButton();
        SetSellButton();

        transform.position = target.GetBuildPosition();
        UI.SetActive(true);
    }

    private void SetUpgradeButton()
    {
        if (!target.isUpgraded)
        {
            upgradeCost.text = $"-$ {target.turretBlueprint.upgradeCost}";
            upgradeButton.interactable = true;
            upgradeButton.GetComponent<Image>().color = baseButtonColor;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
            upgradeButton.GetComponent<Image>().color = upgradedButtonColor;
        }
    }

    private void SetSellButton()
    {
        sellAmount.text = $"+$ {target.turretBlueprint.GetSellAmount()}";
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void SellTurret()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
