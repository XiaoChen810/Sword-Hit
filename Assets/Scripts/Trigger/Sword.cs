using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Pawn pawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision != null && collision.CompareTag("Body"))
        //{
        //    Pawn target = collision.GetComponentInParent<Pawn>();
        //    if(target != null && target != pawn)
        //    {
        //        Debug.Log($"{pawn.gameObject.name}'s {this.gameObject.name} get trigger {target.gameObject.name} : {collision.gameObject.name}");

        //        // ¹¥»÷µÄÊ±ºò±»·ÀÓù
        //        if (pawn.Controller.Action == ActionType.White && target.Controller.Action == ActionType.Red)
        //        {
        //            Debug.Log($"{pawn.gameObject.name} attacks are defended for {target.gameObject.name}");

        //            pawn.Controller.Action = ActionType.Grey;
        //        }
        //    }
        //}
    }
}
