using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private TextMeshProUGUI textGrenadeCount;
    [SerializeField] private TextMeshProUGUI textRepairCount;
    [SerializeField] private TextMeshProUGUI textAmorCount;

    void Start()
    {
        textHP.text = GameManager.Instance.player.Condition.CurHealth.ToString();
        textGrenadeCount.text = GameManager.Instance.player.Condition.CurGrenadeCount.ToString();
        textRepairCount.text = GameManager.Instance.player.Condition.CurRepairKitCount.ToString();
        textAmorCount.text = GameManager.Instance.player.Condition.CurMagazineCount.ToString();
    }

    void Update()
    {
        
    }
}
