using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


/// <summary>
/// Bullet manager for spawning and tracking all of the game's bullets
/// </summary>
public class BulletManager
{
    private readonly Transform _holder;

    /// <summary>
    /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
    /// </summary>
    private readonly Object _bullet;

    public BulletManager(Transform holder)
    {
        _holder = holder;
        _bullet = Resources.Load("BulletPrefab");
    }

    // TODO fill me in
    public void  ForceSpawn(Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime)
    {
        GameObject bullet = (GameObject) Object.Instantiate(_bullet, pos, rotation);
        bullet.transform.SetParent(_holder);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(velocity, deathtime);
    }

}