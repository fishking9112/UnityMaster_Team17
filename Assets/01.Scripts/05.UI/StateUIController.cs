using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private TextMeshProUGUI textGrenadeCount;
    [SerializeField] private TextMeshProUGUI textRepairCount;
    [SerializeField] private TextMeshProUGUI textAmorCount;
    [SerializeField] private Image imageHP;

    void Start()
    {
        textHP.text = GameManager.Instance.player.Condition.CurHealth.ToString();
        textGrenadeCount.text = GameManager.Instance.player.Condition.CurGrenadeCount.ToString();
        textRepairCount.text = GameManager.Instance.player.Condition.CurRepairKitCount.ToString();
        textAmorCount.text = GameManager.Instance.player.Condition.CurMagazineCount.ToString();
        float fillAmount = Mathf.Clamp((float)GameManager.Instance.player.Condition.CurHealth / (float)GameManager.Instance.player.Condition.MaxHealth, 0f, 1f);
        imageHP.fillAmount = fillAmount;
    }

    void Update()
    {
        textHP.text = GameManager.Instance.player.Condition.CurHealth.ToString();
        textGrenadeCount.text = GameManager.Instance.player.Condition.CurGrenadeCount.ToString();
        textRepairCount.text = GameManager.Instance.player.Condition.CurRepairKitCount.ToString();
        textAmorCount.text = GameManager.Instance.player.Condition.CurMagazineCount.ToString();
        float fillAmount = Mathf.Clamp((float)GameManager.Instance.player.Condition.CurHealth / (float)GameManager.Instance.player.Condition.MaxHealth, 0f, 1f);
        imageHP.fillAmount = fillAmount;
    }
}
