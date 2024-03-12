using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public float value = 100;
  public RectTransform valueRectTransform;
  public GameObject gameplayUI;
  public GameObject gameOverScreen;

  public float _maxValue;

  private void Start()
  {
    _maxValue = value;
    DrawHealthBar();
  }

  public void DealDamage(float damage)
  {
    value -= damage;
    if (value <= 0)
    {
      PlayerIsDead();
      //Destroy(gameObject);
    }

    DrawHealthBar();
  }

  public void AddHealth(float amout)
  {
    value += amout;
    value = Mathf.Clamp(value, 0, _maxValue);
    DrawHealthBar();
  }

  private void DrawHealthBar()
  {
    valueRectTransform.anchorMax = new Vector2(value/_maxValue, 1);
  }

  public void PlayerIsDead()
  {
    gameplayUI.SetActive(false);
    gameOverScreen.SetActive(true);
    GetComponent<PlayerController>().enabled = false;
    GetComponent<FireballCaster>().enabled = false;
    GetComponent<CameraRotation>().enabled = false;
  }
}
