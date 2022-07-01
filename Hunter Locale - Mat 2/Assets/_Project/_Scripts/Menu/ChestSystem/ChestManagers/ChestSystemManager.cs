using UnityEngine;
using TMPro;

public class ChestSystemManager : SingletonGenerics<ChestSystemManager>
{
    //[SerializeField] internal TextMeshProUGUI TimerText;
    [SerializeField] internal GameObject Middle_UI;
    [SerializeField] internal GameObject Buttons_UI;
    [SerializeField] internal GameObject ChestPopUp;
    [SerializeField] internal GameObject ChestPopUpUnlocking;

    [SerializeField] private TextMeshProUGUI valueOfGems;
    [SerializeField] private TextMeshProUGUI valueOfCoins;
    [SerializeField] internal TextMeshProUGUI rewardReceivedText;

    private void Start()
    {
        Middle_UI.SetActive(true);
        Buttons_UI.SetActive(true);
        ChestPopUp.SetActive(false);
        ChestPopUpUnlocking.SetActive(false);
    }
    public void CloseUnlockChestPopup()
    {
        Middle_UI.SetActive(true);
        Buttons_UI.SetActive(true);
        ChestPopUp.SetActive(false);
        ChestPopUpUnlocking.SetActive(false);
    }
    public void OpenUnlockChestPopupUnlocking()
    {
        ChestPopUpUnlocking.SetActive(true);
        Buttons_UI.SetActive(false);
        Middle_UI.SetActive(false);
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
        Buttons_UI.SetActive(true);
        Middle_UI.SetActive(true);
        ChestPopUp.SetActive(false);
        ChestPopUpUnlocking.SetActive(false);
    }
}
