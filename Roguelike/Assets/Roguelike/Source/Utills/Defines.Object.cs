using UnityEngine;

public partial class Defines
{
    public enum CreatureState
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
}
