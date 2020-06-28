using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class script_Movement : MonoBehaviour
{
    [Header("Targets")]
    public GameObject gobj_Steak;
    public GameObject gobj_SteakBubble;
    public GameObject gobj_Chicken;
    public GameObject gobj_ChickenBubble;
    public GameObject gobj_Home;
    private GameObject gobj_Target;

    [Header("Animator")]
    public Animator anim_Condition;
    
    [Header("Movement Speed")]
    public float float_Speed;

    [Header("Command Sequencing Object")]
    public script_CommandSequencer customType_Sequencer = null;
    
    private float float_DistanceX;
    private float float_DistanceY;
    
    private bool bool_steakComplete;
    private bool bool_chickenComplete;

    // Start is called before the first frame update
    void Start()
    {
        bool_steakComplete = false;
        bool_chickenComplete = false;
        gobj_Target = gobj_Home;
    }

    void GetSteak()
    {
        if ((bool_steakComplete == false) && (float_DistanceX < -1.5f))
        {
            anim_Condition.SetInteger("int_AnimCondition", 1);
            this.transform.position = new Vector2(this.transform.position.x + .05f, this.transform.position.y);
            if (float_DistanceX >= -1.6f)
            {
                bool_steakComplete = true;
            }
            return;
        }
        gobj_SteakBubble.SetActive(true);
        anim_Condition.SetInteger("int_AnimCondition", 2);
        this.transform.position = Vector2.MoveTowards(this.transform.position, gobj_Home.transform.position, float_Speed * Time.fixedDeltaTime);
        if (this.transform.position.x == 0)
        {
            anim_Condition.SetInteger("int_AnimCondition", -2);
            customType_Sequencer.PushCommand("GRILL STEAK");
            customType_Sequencer.ReadyCommand();
            customType_Sequencer.PushCommand(customType_Sequencer.GenerateJoke()); //Queues a Joke in advanced
            gobj_Target = gobj_Home;
        }
      
    }

    void GetChicken()
    {
        if ((bool_chickenComplete == false) && (float_DistanceY < -1.5f))
        {
            anim_Condition.SetInteger("int_AnimCondition", 3);
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + .05f);
            if (float_DistanceY >= -1.6f)
            {
                bool_chickenComplete = true;
            }
            return;
        }
        gobj_ChickenBubble.SetActive(true);
        anim_Condition.SetInteger("int_AnimCondition", 4);
        this.transform.position = Vector2.MoveTowards(this.transform.position, gobj_Home.transform.position, float_Speed * Time.fixedDeltaTime);
        if (this.transform.position.y == 0)
        {
            anim_Condition.SetInteger("int_AnimCondition", -4);
            customType_Sequencer.PushCommand("GRILL CHICKEN");
            customType_Sequencer.ReadyCommand();
            customType_Sequencer.PushCommand(customType_Sequencer.GenerateJoke()); //Queues a Joke in advanced
            gobj_Target = gobj_Home;
        }
        
    }

    private void Move()
    {
        if (gobj_Target == gobj_Steak)
            GetSteak();
        else if (gobj_Target == gobj_Chicken)
            GetChicken();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float_DistanceX = this.transform.position.x - gobj_Target.transform.position.x;
        float_DistanceY = this.transform.position.y - gobj_Target.transform.position.y;
        Move();
    }

    public void CorrectMoveMatchListener(string str_command)
    {
        string str_target = str_command.Split().Last();
        Debug.Log(str_command);
        Debug.Log(str_target);
        switch (str_target)
        {
            case "STEAK":
                gobj_Target = gobj_Steak;
                break;
            case "CHICKEN":
                gobj_Target = gobj_Chicken;
                break;
        }

    }
}