using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Movement : MonoBehaviour
{
    public GameObject gobj_Target;
    public GameObject gobj_Home;
    public Animator anim_Condition;
    public float float_Speed;
    private float float_DistanceX;
    private float float_DistanceY;
    private bool bool_steakComplete;
    private bool bool_chickenComplete;

    // Start is called before the first frame update
    void Start()
    {
        bool_steakComplete = false;
        bool_chickenComplete = false;
    }

    void GetSteak()
    {
        if ((bool_steakComplete == false) && (float_DistanceX > 1.5f))
        {
            anim_Condition.SetInteger("int_AnimCondition", 3);
            this.transform.position = new Vector2(this.transform.position.x - .01f, this.transform.position.y);
            if (float_DistanceX <= 1.6f)
            {
                bool_steakComplete = true;
            }
            return;
        }
        gobj_Target.GetComponent<Renderer>().enabled = false;
        anim_Condition.SetInteger("int_AnimCondition", 4);
        this.transform.position = Vector2.MoveTowards(this.transform.position, gobj_Home.transform.position, float_Speed * Time.fixedDeltaTime);
        if (this.transform.position.x == 0)
        {
            anim_Condition.SetInteger("int_AnimCondition", -4);
        }
    }

    void GetChicken()
    {
        if ((bool_chickenComplete == false) && (float_DistanceY > 1.5f))
        {
            anim_Condition.SetInteger("int_AnimCondition", 1);
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - .01f);
            if (float_DistanceY <= 1.6f)
            {
                bool_chickenComplete = true;
            }
            return;
        }
        gobj_Target.GetComponent<Renderer>().enabled = false;
        anim_Condition.SetInteger("int_AnimCondition", 2);
        this.transform.position = Vector2.MoveTowards(this.transform.position, gobj_Home.transform.position, float_Speed * Time.fixedDeltaTime);
        if (this.transform.position.y == 0)
        {
            anim_Condition.SetInteger("int_AnimCondition", -2);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float_DistanceX = this.transform.position.x - gobj_Target.transform.position.x;
        float_DistanceY = this.transform.position.y - gobj_Target.transform.position.y;
        GetSteak();
    }
}