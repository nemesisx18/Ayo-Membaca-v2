using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionStep : MonoBehaviour
{
    [SerializeField] private string objectiveGoal;
    [SerializeField] private bool stepDone = false;

    public string ObjectiveGoal => objectiveGoal;
    public bool StepDone => stepDone;

    public void SetBool()
    {
        stepDone = true;
    }
}
