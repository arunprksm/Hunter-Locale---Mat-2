using UnityEngine;
using TMPro;

public class ChestSystemManager : SingletonGenerics<ChestSystemManager>
{
    [SerializeField] internal TextMeshProUGUI TimerText;
    [SerializeField] internal GameObject ChestSlots;
    [SerializeField] internal GameObject SpwanChestButton;
    [SerializeField] internal GameObject ChestPopUp;
    [SerializeField] internal GameObject ChestPopUpUnlocking;

    [SerializeField] private TextMeshProUGUI valueOfCoins;
    [SerializeField] private TextMeshProUGUI valueOfGems;
    [SerializeField] internal TextMeshProUGUI rewardReceivedText;

    public void CloseUnlockChestPopup()
    {
        ChestSlots.SetActive(true);
        SpwanChestButton.SetActive(true);
        ChestPopUp.SetActive(false);
        ChestPopUpUnlocking.SetActive(false);
    }
    public void OpenUnlockChestPopupUnlocking()
    {
        ChestPopUpUnlocking.SetActive(true);
        SpwanChestButton.SetActive(false);
        ChestSlots.SetActive(false);
        ChestPopUp.SetActive(false);
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }

    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void CloseButton()
    {
        SpwanChestButton.SetActive(true);
        ChestSlots.SetActive(true);
        ChestPopUp.SetActive(false);
        ChestPopUpUnlocking.SetActive(false);
    }
}
