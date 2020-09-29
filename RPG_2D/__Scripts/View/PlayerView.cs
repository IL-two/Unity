using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField]
    private GameObject Effect; // Визуаьлный эффект потери здоровья
    [SerializeField]
    private GameObject levelUp; // Визуальный эффект повышения уровня
    [SerializeField]
    private GameObject textDamage; // Визуальный эффект полученного урона
    [SerializeField]
    private GameObject levelUpText; // Текстовый эффект получения уровня
    [SerializeField]
    private Slider slidetHeath; // Шкала здоровья
    [SerializeField]
    private Slider sliderExp; // Шкала опыта
    [SerializeField]
    private Text levelText; // Текст счетчика уровня
    [SerializeField]
    private GameObject GameOverMenu; // Текст проигрыша

    private PlayerModel playerModel;
    private PlayerController playerController;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerModel = playerController.player;
        slidetHeath.maxValue = playerModel.MaxHealth;
        slidetHeath.value = playerModel.MaxHealth; // Установление шкалы здоровья
        sliderExp.maxValue = playerModel.MaxExperience;
        levelText.text = "Level: " + playerModel.Level.ToString();

        playerController.levelUp += UpdateSliderHealth;
    }

    public void ViewEffectDamage(Vector3 vector, int ammoutn)
    {
        Instantiate(Effect, vector, Quaternion.identity);
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 1f);
        textDamage.GetComponentInChildren<TextDamage>().damage = ammoutn;
        Instantiate(textDamage, damagePos, Quaternion.identity);
    }

    public void ViewEffectLevelUp(Vector3 vector)
    {
        sliderExp.value = playerController.currentExp;
        sliderExp.maxValue = playerController.MaxExp();
        Instantiate(levelUp, vector, Quaternion.identity);
        levelText.text = "Level: " + playerModel.Level.ToString();

        Vector2 levelUpPos = new Vector2(transform.position.x + 1f, transform.position.y + 2f);
        Instantiate(levelUpText, levelUpPos, Quaternion.identity);
    }

    public void OneDeadMenu()
    {
        GameOverMenu.SetActive(true);
    }

    public void UpdateSliderHealth(int value)
    {
        slidetHeath.value = value;
    }

    public void UpdateSliderExperience(int value)
    {
        sliderExp.value = value;
    }

    public void UpdateSliderHealth()
    {
        slidetHeath.maxValue = playerController.player.MaxHealth;
    }
}
