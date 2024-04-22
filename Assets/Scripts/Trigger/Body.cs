using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Pawn pawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����
        if (collision != null && collision.CompareTag("Sword"))
        {
            Pawn target = collision.GetComponentInParent<Pawn>();
            if (target != null && target != pawn)
            {
                Debug.Log($"{pawn.gameObject.name}'s {this.gameObject.name} get trigger {target.gameObject.name} : {collision.gameObject.name}");

                // û�з�����ʱ���ܵ�����
                if (pawn.Controller.Action != ActionType.Red && target.Controller.Action == ActionType.White)
                {
                    Debug.Log($"{pawn.gameObject.name} get damage from {target.gameObject.name}");
                    float force = (pawn.transform.position.x < target.transform.position.x) ? -target.Force : target.Force;
                    pawn.GetDamage(5, force);
                }
                // ������ʱ���ܵ�����
                if (pawn.Controller.Action == ActionType.Red && target.Controller.Action == ActionType.White)
                {
                    Debug.Log($"{target.gameObject.name} attacks are defended for {pawn.gameObject.name}");
                    target.Controller.Action = ActionType.Grey;
                    pawn.Controller.DefendSuccessly();
                }
            }
        }
    }
}
