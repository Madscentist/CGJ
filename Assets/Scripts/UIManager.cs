using System.Collections;
using System.Collections.Generic;
using Mmang;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    [SerializeField] private Canvas _canvas;

    public static Canvas Canvas => Instance?._canvas;

    protected override void OnAwake()
    {
        base.OnAwake();
        if (_canvas == null)
            _canvas = GetComponent<Canvas>();
    }
}
