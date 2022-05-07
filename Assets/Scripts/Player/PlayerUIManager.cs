using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{

    public Slider hpSlider;

    public void UpdateHp(int currentHp)
    {
        hpSlider.value = currentHp;
    }
}
