using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory :MonoBehaviour,IPowerUpFactory
{
    [SerializeField] private PowerUp[] _powerUp;

    private Dictionary<string, PowerUp> _idToPowerUp;
    private void Awake()
    {
        _idToPowerUp = new Dictionary<string, PowerUp>();

        foreach (var powerup in _powerUp)
        {
            _idToPowerUp.Add(powerup.Id, powerup);
        }

    }
    public PowerUp Create(string ID, Transform currentPosition)
    {
        if (!_idToPowerUp.TryGetValue(ID, out var powerUp))
        {
            throw new Exception(message: $"power whit id {ID} does not exit");
        }


        return Instantiate(powerUp , currentPosition.position, Quaternion.identity);

    }
}
