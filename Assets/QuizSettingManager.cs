using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class QuizSettingManager : MonoBehaviour
{
    public static QuizSettingManager Instance;

    [SerializeField] TMP_Dropdown questionDropdown;
    [SerializeField] TMP_Dropdown choiceDropdown;

    [SerializeField] GameObject threeChoicePanel;
    [SerializeField] GameObject fourChoicePanel;
    [SerializeField] GameObject initPanel;

    [SerializeField] GameObject threeChoiceSettingPanel;
    [SerializeField] GameObject fourChoiceSettingPanel;

    [SerializeField] Transform[] parentObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        questionDropdown.onValueChanged.AddListener(delegate { SetNumberOfQuestion(questionDropdown); });
        choiceDropdown.onValueChanged.AddListener(delegate { SetNumberOfChoice(choiceDropdown); });

    }

    void SetNumberOfQuestion(TMP_Dropdown questionDropdown)
    {
        string optionName = questionDropdown.options[questionDropdown.value].text;
        int numberOfQuestion = Int32.Parse(optionName);

        Array.ForEach(parentObj, parentObj =>
        {
            foreach (Transform child in parentObj)
            {
                Destroy(child.gameObject);
            }
        });

        for (int i = 0; i < numberOfQuestion; i++)
        {
            Instantiate(threeChoiceSettingPanel, parentObj[0]);
            Instantiate(fourChoiceSettingPanel, parentObj[1]);
        }

    }

    void SetNumberOfChoice(TMP_Dropdown choiceDropdown)
    {
        string optionName = choiceDropdown.options[choiceDropdown.value].text;

        if (optionName == "3")
        {
            initPanel.SetActive(false);
            threeChoicePanel.SetActive(true);
            fourChoicePanel.SetActive(false);
        }
        else if (optionName == "4")
        {
            initPanel.SetActive(false);
            threeChoicePanel.SetActive(false);
            fourChoicePanel.SetActive(true);
        }
        else if( optionName == "select")
        {
            initPanel.SetActive(true);
            threeChoicePanel.SetActive(false) ;
            fourChoicePanel.SetActive(false);

            
        }
    }
}
