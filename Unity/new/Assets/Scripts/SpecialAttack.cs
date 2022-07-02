using UnityEngine;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour
{

    public Image SpecialAttackBar;

    public GameObject ReadyText;
    public GameObject ChargingText;

    public float ChargingAmount = 0;
    public float minCharge = 0;
    public float maxCharge = 1;

    // Start is called before the first frame update
    void Start()
    {
        ChargingAmount = 0;
        ChargingAmount = Mathf.Clamp(ChargingAmount, minCharge, maxCharge);
        SpecialAttackBar.fillAmount = ChargingAmount / maxCharge;
        SpecialAttackBar.gameObject.SetActive(false);
        ChargingText.SetActive(true);
        ReadyText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaxAmount(float value)
    {
        if (value == 0)
        {
            SpecialAttackBar.gameObject.SetActive(false);
            value = 1;
        }
        else
        {
            SpecialAttackBar.gameObject.SetActive(true);
        }

        maxCharge = value;
        ChargingAmount = 0;
        ChargingAmount = Mathf.Clamp(ChargingAmount, minCharge, maxCharge);
        SpecialAttackBar.fillAmount = ChargingAmount / maxCharge;
    }

    public void Charging(float value)
    {
        ChargingAmount += value;
        ChargingAmount = Mathf.Clamp(ChargingAmount, minCharge, maxCharge);
        SpecialAttackBar.fillAmount = ChargingAmount / maxCharge;

        if (ChargingAmount == maxCharge)
        {
            ReadyText.SetActive(true);
            ChargingText.SetActive(false);
        }
        else
        {
            ChargingText.SetActive(true);
            ReadyText.SetActive(false);
        }
    }

    public void Resetting()
    {
        ChargingAmount = 0;
        ChargingAmount = Mathf.Clamp(ChargingAmount, minCharge, maxCharge);
        SpecialAttackBar.fillAmount = ChargingAmount / maxCharge;
        ChargingText.SetActive(true);
        ReadyText.SetActive(false);
    }
    
}
