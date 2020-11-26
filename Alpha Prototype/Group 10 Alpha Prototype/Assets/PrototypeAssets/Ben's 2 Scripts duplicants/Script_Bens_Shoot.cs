using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bens_Shoot : MonoBehaviour
{

    public Transform _Cannon;          // the barrel obj.
    public Rigidbody _Projectile;      // the prefab 

    public GameObject GameManager;

    public float _bulletDamage;
    public float _bulletDamageNormal;
    public float _bulletDamageUpgraded;

    public AudioClip gunShot;

    private int StateInt = 0;

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        _bulletDamage = _bulletDamageNormal;
    }
    void Update()
    {
        if(StateInt == GameManager.GetComponent<Alex.Carvalho.Script_Player_Scene_Manager>()._PlayerStateInt)
        {
            if (Input.GetKeyDown(KeyCode.G) && GameManager.GetComponent<Alex.Carvalho.Beta_Script_GameManager>().CanShoot && GameManager.GetComponent<Alex.Carvalho.Script_Maintenence_Manager>().TurretWorking)
            {
                GameManager.GetComponent<Alex.Carvalho.Beta_Script_GameManager>().DecreaseAmmo();
                Rigidbody fireBullet;
                fireBullet = Instantiate(_Projectile, _Cannon.position, _Cannon.rotation) as Rigidbody;
                fireBullet.AddForce(_Cannon.forward * 10000);

                AudioManager.Instance.PlayEffects(gunShot, 0.2f);
            }
        }

        if (GameManager.GetComponent<Alex.Carvalho.Beta_Script_GameManager>().UpgradedDamage)
        {
            _bulletDamage = _bulletDamageUpgraded;
        }
        else
        {
            _bulletDamage = _bulletDamageNormal;
        }
    }
}
