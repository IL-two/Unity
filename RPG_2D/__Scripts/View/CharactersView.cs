using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersView : MonoBehaviour
{
    public GameObject charactersUI;

    public Text textHealth;
    public Text textMaxHealth;
    public Text textLevel;
    public Text textStrength;
    public Text textDexterity;
    public Text textCurrExp;
    public Text textMaxExp;

    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        charactersUI.SetActive(false);

        controller = PlayerController.playerController;
        controller.levelUp += UpdateCharacterText;

        textHealth.text = "Health: " + PlayerController.playerController.currentHealth;
        textMaxHealth.text = "Max Health: " + PlayerController.playerController.player.MaxHealth;
        textLevel.text = "Level: " + PlayerController.playerController.player.Level;
        textStrength.text = "Strength: " + PlayerController.playerController.player.Strenght;
        textDexterity.text = "Dexterity: " + PlayerController.playerController.player.Dexterity;
        textCurrExp.text = "Experience: " + PlayerController.playerController.currentExp;
        textMaxExp.text = "Next Level: " + PlayerController.playerController.player.MaxExperience;
    }

    private void UpdateCharacterText()
    {
        textMaxHealth.text = "Max Health: " + PlayerController.playerController.player.MaxHealth;
        textLevel.text = "Level: " + PlayerController.playerController.player.Level;
        textStrength.text = "Strength: " + PlayerController.playerController.player.Strenght;
        textDexterity.text = "Dexterity: " + PlayerController.playerController.player.Dexterity;
        textMaxExp.text = "Next Level: " + PlayerController.playerController.player.MaxExperience;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (charactersUI.activeInHierarchy)
                charactersUI.SetActive(false);
            else
                charactersUI.SetActive(true);
        }

        textHealth.text = "Health: " + PlayerController.playerController.currentHealth;
        textCurrExp.text = "Experience: " + PlayerController.playerController.currentExp;        
    }
}
