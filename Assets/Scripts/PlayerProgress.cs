using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Добавили using-директиву

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP; // Изменили тип переменной
    private int _levelValue = 1;
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue +=1;
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }
    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
