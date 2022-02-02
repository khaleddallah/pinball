using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator[] animators;

    public float waitToTakeInput = 0.3f;
    public float nextTimeTakingInput;
    // Start is called before the first frame update
    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if ( Time.timeSinceLevelLoad > nextTimeTakingInput && input != 0)
        {
            nextTimeTakingInput = Time.timeSinceLevelLoad + waitToTakeInput;
            if(input>0){
                animators[0].SetTrigger("move");
            }
            else{
                animators[1].SetTrigger("move");
            }
        }
    }
}
