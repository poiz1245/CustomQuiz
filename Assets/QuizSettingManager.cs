using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class QuizSettingManager : MonoBehaviour
{
    public static QuizSettingManager Instance;

    [SerializeField] TMP_Dropdown questionDropdown;
    [SerializeField] TMP_Dropdown choiceDropdown;

    [SerializeField] GameObject parentObj;
    [SerializeField] GameObject quizSettingPanel;
    [SerializeField] GameObject ChoiceObj;


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

        if (optionName == "10")
        {
            print("10");
        }
        else if (optionName == "20")
        {
            print("20");
        }
        else if (optionName == "30")
        {
            print("30");
        }
    }

    void SetNumberOfChoice(TMP_Dropdown choiceDropdown)
    {
        string optionName = choiceDropdown.options[choiceDropdown.value].text;

        if (optionName == "3")
        {
            print("3");
        }
        else if (optionName == "4")
        {
            print("4");
        }
    }
}
