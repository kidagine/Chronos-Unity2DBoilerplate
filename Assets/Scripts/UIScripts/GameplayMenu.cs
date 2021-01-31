﻿using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class GameplayMenu : MonoBehaviour, ISubMenu
{
    [SerializeField] private Selectable _startingOption = default;
    [SerializeField] private GameStatistics _gameStatistics = default;


    public void OpenMenu(GameObject menu)
    {
        gameObject.SetActive(false);
        if (menu.TryGetComponent(out ISubMenu subMenu))
        {
            subMenu.Activate();
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        _startingOption.Select();
    }

    public void ShowFPS(bool state)
    {
        _gameStatistics.ShowFPS(state);
    }

    public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
