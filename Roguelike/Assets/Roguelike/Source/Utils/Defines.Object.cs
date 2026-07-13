using UnityEngine;

public partial class Defines
{
    public enum StateType
    {
        None,
        OnEnter,
        OnUpdate,
        OnExit,
        OnFinish,
    }

    public enum ObjectState
    {
        None,
        Idle,
        Move,
        Attack,
        Skill,
        Hit,
        Dead,
    }

    public enum Direction
    {
        Right,
        Left,
        Up,
        Down,
    }

    public enum AnimationEventType
    {
        Idle,
        Move,
        Attack,
        Hit,
        Dead,
    }
}
