using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    public PawnController Controller;
    public bool CanControll;
    public float Hp = 100;
    public float MaxHp = 100;
    public Slider HeathSlider;
    [SerializeField] private float _force = 100;
    public float Force
    {
        get 
        { 
            return _force;
        }
        set 
        {
            _force = value < MaxForce ? value : MaxForce;
            _force = value > ForceBase ? value : ForceBase;
        }
    }
    public float ForceBase = 100;
    public float Aforce = 100;
    public float MaxForce = 500;
    public bool IsDie;
    private void Start()
    {
        Controller = GetComponent<PawnController>();
        Init();
    }

    public void Init()
    {
        Hp = MaxHp;
        IsDie = false;
    }

    private void Update()
    {
        if (IsDie) return;
        HeathSlider.value = Hp / MaxHp;
        if(Hp <= 0)
        {
            IsDie = true;
        }
    }

    public void GetDamage(float value, float force)
    {
        Hp -= value;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(force, 0));
    }

}
