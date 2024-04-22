using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    // Component
    public Animator anim;
    public Rigidbody2D rb;
    public Collider2D leg1;
    public Collider2D leg2;
    public Pawn pawn;

    [SerializeField] 
    private ActionType _actionType;
    public ActionType Action
    {
        get { return _actionType; }
        set
        {
            anim.SetInteger("Action", ((int)value));
            _actionType = value;
        }   
    }

    public void Start()
    {
        _actionType = ActionType.None;
    }

    [SerializeField]
    private float _time_KeyDown;
    [SerializeField]
    private float _time_DefendSuccessly;
    [SerializeField]
    private float _time_Blue = 0.5f;
    [SerializeField]
    private float _time_Golden = 1f;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;

    [Header("KEY")]
    public KeyCode k_MoveLeft;
    public KeyCode k_MoveRight;
    public KeyCode k_Attack;
    public KeyCode k_Defend;
    public KeyCode k_Jump;

    [Header("Jump")]
    public LayerMask GroundLayer;
    public bool OnGround;

    public void Update()
    {
        if (pawn == null || !pawn.CanControll) return;
        if (_actionType == ActionType.Grey) return;
        if (_actionType == ActionType.Golden) return;
        if (pawn.IsDie)
        {
            anim.SetBool("IsDie", true);
            return;
        }
        ActionUpdate();
        MoveUpdate();
        FlipUpdate();
        OnGround = (leg1.IsTouchingLayers(GroundLayer) || leg2.IsTouchingLayers(GroundLayer));
    }

    public void DefendSuccessly()
    {
        _time_DefendSuccessly = Time.time;
    }

    private void FlipUpdate()
    {
        if (Input.GetKey(k_MoveLeft))
        {
            transform.localScale = Vector3.one;
        }
        if (Input.GetKey(k_MoveRight))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void MoveUpdate()
    {
        if (_actionType == ActionType.None)
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(k_MoveLeft))
            {
                dir = new Vector3(-1, 0);
            }
            if (Input.GetKey(k_MoveRight))
            {
                dir = new Vector3(1, 0);
            }
            Vector2 force = dir * _speed;
            // 检查速度是否超过最大值
            if (rb.velocity.magnitude < _maxSpeed)
            {
                rb.AddForce(force);
            }
            // 如果超过最大值，将速度限制为最大值
            else
            {
                rb.velocity = rb.velocity.normalized * _maxSpeed;
            }
            anim.SetFloat("Speed", Mathf.Abs(dir.x));

            if (Input.GetKey(k_Jump) && OnGround)
            {
                rb.AddForce(new Vector2(0, _jumpForce));
                OnGround = false;
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        anim.SetBool("Jump", !OnGround);        
    }

    private void ActionUpdate()
    {
        if (Input.GetKeyDown(k_Attack))
        {
            _time_KeyDown = Time.time;
            pawn.Force += pawn.ForceBase;
            if (Time.time < _time_DefendSuccessly + _time_Golden)
            {
                Action = ActionType.Golden;
                return;
            }
        }
        if (Input.GetKey(k_Attack))
        {
            if (Time.time > _time_KeyDown + _time_Blue)
            {
                Action = ActionType.Blue;
                pawn.Force += pawn.Aforce * Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(k_Attack))
        {
            Action = ActionType.White;
        }
        if (Input.GetKeyDown(k_Defend))
        {
            _time_KeyDown = Time.time;
            Action = ActionType.Red;
        }
    }
}
