﻿using UnityEngine;

public class UIGuideTextHolder : MonoBehaviour
{
    public GuideText guideText;
    private UIGuideTextTemplate _ui;

    public void CreateUI()
    {
        _ui = UIGeneration.Instance.CreateUI(guideText);
        _ui.SetToDo();
    }

    public void SetDone()
    {
        _ui.SetDone();
    }
}
