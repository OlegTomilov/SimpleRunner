using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearths = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if(_hearths.Count < value)
        {
            int createHealth = value - _hearths.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if(_hearths.Count > value)
        {
            int decreateHealth =_hearths.Count - value;

            for (int i = 0; i < decreateHealth; i++)
            {
                DestroyHeart(_hearths[_hearths.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearths.Remove(heart);
        heart.ToEmpty();
    }    

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearths.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
