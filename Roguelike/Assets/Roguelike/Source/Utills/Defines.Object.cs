using UnityEngine;

public partial class Defines
{
    public enum ObjectState
    {
        None,
        Idle,
        Move,
        Attack,
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

    public enum StatType
    {
        None,
        BaseAttack,
        BaseDefense,
        BaseHp,
    }
}
