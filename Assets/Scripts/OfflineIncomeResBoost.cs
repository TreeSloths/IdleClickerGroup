using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineIncomeResBoost : MonoBehaviour
{
    public AddOfflineRes AddOfflineRes;


    private void boostFourHours()
    {
        while (AddOfflineRes.nowMinusThen != 14400)
        {
            var boost = AddOfflineRes.offlineRes * 4;
        }
    }
}