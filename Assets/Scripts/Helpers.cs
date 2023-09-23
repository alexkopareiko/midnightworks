using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Newtonsoft.Json; 
using System.Collections;
using Unity.VisualScripting;
using static Constants;
using System.Data.Common;

public static class Helpers
{

    #region Math Methods

    public static float GetXZAngle(Vector3 v1, Vector3 v2)
    {
        Vector2 _v1 = new Vector2(v1.x, v1.z);
        Vector2 _v2 = new Vector2(v2.x, v2.z);
        float angle = Vector2.Angle(_v1, _v2);
        return angle;
    }
    #endregion

    #region Offset for RectTransform
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }
    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }
    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }
    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
    #endregion

    #region FIX RECT SCALE BUG

    public static void FixScaleBug(this RectTransform rt)
    {
        rt.localScale = Vector3.one;
    }

    #endregion

    #region Open/Close Menu

    public static void CloseMenu(this GameObject menu)
    {
        CanvasGroup canvasGroup = menu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public static void OpenMenu(this GameObject menu)
    {
        CanvasGroup canvasGroup = menu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
    public static void TriggerMenu(this GameObject menu)
    {
        CanvasGroup canvasGroup = menu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = canvasGroup.alpha == 1 ? 0 : 1;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        canvasGroup.interactable = !canvasGroup.interactable;
    }

    #endregion

    #region Button Down/Up

    public static void ButtonDown(this GameObject btn)
    {
        RectTransform _btn = btn.GetComponent<RectTransform>();
        Vector3 scale = _btn.localScale * 0.9f;
        _btn.localScale = scale;
    }

    public static void ButtonUp(this GameObject btn)
    {
        RectTransform _btn = btn.GetComponent<RectTransform>();
        Vector3 scale = _btn.localScale * 1.1111f;
        _btn.localScale = scale;
    }

    #endregion

    #region SAVED DATA

    #region SOUND_MUSIC

    public static bool GetPPSoundMusic()
    {
        bool _musicVolume = true;
        string key = Constants.PP.SOUND_MUSIC;
        if (SaveSystem.HasKey(key))
        {
            _musicVolume = SaveSystem.GetBool(key);
        }
        else
        {
            SetPPSoundMusic(_musicVolume);
        }
        return _musicVolume;
    }

    public static void SetPPSoundMusic(bool value)
    {
        SaveSystem.SetBool(Constants.PP.SOUND_MUSIC, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #region SOUND_EFFECTS

    public static bool GetPPSoundEffects()
    {
        bool _effectVolume = true;
        string key = Constants.PP.SOUND_EFFECTS;
        if (SaveSystem.HasKey(key))
        {
            _effectVolume = SaveSystem.GetBool(key);
        }
        else
        {
            SetPPSoundEffects(_effectVolume);
        }
        return _effectVolume;
    }

    public static void SetPPSoundEffects(bool value)
    {
        SaveSystem.SetBool(Constants.PP.SOUND_EFFECTS, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #region COINS

    public static int GetPPScore(int initialValue = 0)
    {
        int _val = initialValue;
        string key = Constants.PP.SCORE;
        if (SaveSystem.HasKey(key))
        {
            _val = SaveSystem.GetInt(key);
        }
        else
        {
            SetPPScore(_val);
        }
        return _val;
    }

    public static void SetPPScore(int value)
    {
        SaveSystem.SetInt(Constants.PP.SCORE, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #region USE_ANALYTICS
    public static bool GetPPUseAnalytics()
    {
        bool _value = true;
        string key = Constants.PP.USE_ANALYTICS;
        if (SaveSystem.HasKey(key))
        {
            _value = SaveSystem.GetBool(key);
        }
        else
        {
            SetPPUseAnalytics(_value);
        }
        return _value;
    }

    public static void SetPPUseAnalytics(bool value)
    {
        SaveSystem.SetBool(Constants.PP.USE_ANALYTICS, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #region PRIVACY_POLICY_AGREE
    public static bool GetPPPrivacyPolicy()
    {
        bool _value = false;
        string key = Constants.PP.PRIVACY_POLICY_AGREE;
        if (SaveSystem.HasKey(key))
        {
            _value = SaveSystem.GetBool(key);
        }
        else
        {
            SetPPPrivacyPolicy(_value);
        }
        return _value;
    }

    public static void SetPPPrivacyPolicy(bool value)
    {
        SaveSystem.SetBool(Constants.PP.PRIVACY_POLICY_AGREE, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #region TUTORIAL_SHOWED
    /// <summary>
    /// Need for tutorial
    /// </summary>
    /// <returns></returns>
    public static bool GetPPTutorialShowed()
    {
        bool _value = false;
        string key = Constants.PP.TUTORIAL_SHOWED;
        if (SaveSystem.HasKey(key))
        {
            _value = SaveSystem.GetBool(key);
        }
        else
        {
            SetPPTutorialShowed(_value);
        }
        return _value;
    }

    public static void SetPPTutorialShowed(bool value)
    {
        SaveSystem.SetBool(Constants.PP.TUTORIAL_SHOWED, value);
        SaveSystem.SaveToDisk();
    }

    #endregion

    #endregion
}
