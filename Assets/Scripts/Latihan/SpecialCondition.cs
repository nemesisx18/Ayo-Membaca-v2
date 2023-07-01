using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCondition : MonoBehaviour
{
    [SerializeField] private GameObject border;
    [SerializeField] private CameraFollow cm;

    private InstructionManager instruction;

    private void Start()
    {
        instruction = GetComponent<InstructionManager>();
    }

    private void Update()
    {
        if(instruction.StepIndex == 10)
        {
            border.SetActive(false);
            cm.ChangeMaxX(119);
        }
    }
}
