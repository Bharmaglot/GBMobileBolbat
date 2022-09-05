using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunAbility : IAbility
{
    private readonly float _speed;
    private readonly Rigidbody2D _viewPrefab;

    public GunAbility(ResourcePath _viewPath, float speed)
    {
        _speed = speed;
        ResourceLoader.LoadPrefab(_viewPath).GetComponent<Rigidbody2D>();
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = object.Instantiate(_viewPrefab);  
        projectile.AddForce(activator.GetViewObject().transform.right * _speed, ForceMode2D.Force);
    }
}
