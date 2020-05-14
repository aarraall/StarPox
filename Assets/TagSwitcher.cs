using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSwitcher : MonoBehaviour
{
    private State state;
    private enum State
    {
        Alive,
        Dead,
    }
    // Start is called before the first frame update
    void Start()
    {
        state = State.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        //todo handle char's state by here
        switch (state)
        {
            case State.Alive:
                break;
            case State.Dead:
                break;
        }
    }
}
