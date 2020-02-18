using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    private int leftGoals = 0;
    private int rightGoals = 0;

    private TextMesh vsMesh;

    // Start is called before the first frame update
    void Start()
    {
        vsMesh = GameObject.Find("Text").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Ball collision!");
        if(col.gameObject.name == "green_goal")
        {
            Debug.Log("Left goal");
            rightGoals += 1;
            transform.position = Vector3.zero;
        } 
        else if(col.gameObject.name == "purple_goal") {
            Debug.Log("Right goal");
            leftGoals += 1;
            transform.position = Vector3.zero;
        }
        vsMesh.text = leftGoals + " x " + rightGoals;
    }
}
