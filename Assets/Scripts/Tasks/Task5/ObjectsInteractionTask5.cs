using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteractionTask5 : MonoBehaviour
{
    // TODO: Подпишитесь на событие ItemSpawned класса Shelf
    // TODO: Если на полке станет более трех предметов - вызовите у объекта Shelf метод Fall
    // TODO: Логика должна работать для обоих полок сцены

    private const int MAX_COUNT_ON_SHELF = 3;
        
    [SerializeField] private Shelf[] _shelves;

    private readonly Dictionary<Shelf, int> _itemOnShelves = new();

    private void Awake()
    {
        foreach (var shelf in _shelves)
        {
            shelf.ItemSpawned += OnItemSpawned;
        }
    }

    private void OnDestroy()
    {
        foreach (var shelf in _shelves)
        {
            shelf.ItemSpawned -= OnItemSpawned;
        }
    }

    private void OnItemSpawned(Shelf shelf)
    {
        _itemOnShelves.TryAdd(shelf, 0);
        _itemOnShelves[shelf]++;

        if (_itemOnShelves[shelf] > MAX_COUNT_ON_SHELF)
        {
            shelf.Fall();
        }
    }
}