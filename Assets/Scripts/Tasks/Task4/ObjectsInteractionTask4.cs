using System;
using UnityEngine;

public class ObjectsInteractionTask4 : MonoBehaviour
{
    // TODO: Подпишитесь на событие TimerIsUp класса Toaster созданием объекта Waffle в точке WaffleRoot (из папки Prefabs)

    [SerializeField] private Toaster _toster;
    [SerializeField] private GameObject _wafflePrefab;
    [SerializeField] private Transform _waffleRoot;

    private void Awake()
    {
        _toster.TimerIsUp += OnTimerIsUp;
    }

    private void OnTimerIsUp()
    {
        Instantiate(_wafflePrefab, _waffleRoot);
    }

    private void OnDestroy()
    {
        _toster.TimerIsUp -= OnTimerIsUp;
    }
}