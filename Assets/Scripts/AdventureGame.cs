using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // Variables
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for(int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                state = nextStates[i];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            state = startingState;
        }

        textComponent.text = state.GetStateStory();
    }
}
