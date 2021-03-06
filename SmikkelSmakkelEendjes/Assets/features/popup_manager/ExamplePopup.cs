﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ExamplePopup : PopupBase {

    public override void Open()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, .33f).SetEase(Ease.OutBack);
    }

    public override void Close()
    {
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, .33f).SetEase(Ease.InCubic).OnComplete(CompleteClose);
    }

    private void CompleteClose()
    {
        PopupManager.Instance.RegisterClosed(this);
    }
}
