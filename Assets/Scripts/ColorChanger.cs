using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;
    [SerializeField] private float _colorChangeSpeed;
    [SerializeField] private Alarm _alarm;

    private Color _targetColor;
    private bool _isActive = false;

    private void OnEnable()
    {
        _targetColor = _firstColor;
        _alarm.ColorChange += OnColorChanged;
    }

    private void OnDisable()
    {
        _alarm.ColorChange -= OnColorChanged;
    }

    private void Update()
    {
        if (_isActive)
        {
            _renderer.color = Color.Lerp(_renderer.color, _targetColor, Time.deltaTime * _colorChangeSpeed);

            if (_renderer.color == _firstColor)
            {
                _targetColor = _secondColor;
            }
            else if (_renderer.color == _secondColor)
            {
                _targetColor = _firstColor;
            }
        }
    }

    public void OnColorChanged()
    {
        _isActive = !_isActive;
        _renderer.color = _firstColor;
    }
}

                              