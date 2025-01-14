using TMPro;
using UnityEngine;

public class SelectedWeaponDisplay : MonoBehaviour
{
    [SerializeField] private IntEvent currentWeapon,weponCount;

    [SerializeField] private TextMeshProUGUI[] displayText;
    int currentDisplay=0;
    bool isFirstTime = true;
    private void OnEnable()
    {
        currentWeapon.RegisterDelegate(AttachedIntEventChanged);
        weponCount.RegisterDelegate(WeaponCountChanged);
    }

    private void OnDisable()
    {
        currentWeapon.UnregisterDelegate(AttachedIntEventChanged);
        weponCount.UnregisterDelegate(WeaponCountChanged);
    }

    private void AttachedIntEventChanged(bool isDebug)
    {
        displayText[currentWeapon.IntValue].color = Color.red;
        displayText[currentDisplay].color = Color.white;
        currentDisplay = currentWeapon.IntValue;
        if (isFirstTime)
        {
            isFirstTime = false;
            displayText[currentDisplay].color = Color.red;
        }
    }

    private void WeaponCountChanged(bool isDebug)
    {
        for (int i = 0; i < weponCount.IntValue; i++)
        {
            displayText[i].color = Color.white;
        }

        for (int i = displayText.Length; i > weponCount.IntValue; i--)
        {
            displayText[i-1].color = Color.gray;
        }
    }
}
