using UnityEngine;

public partial class PlayerControl : BaseControl
{
    private void BindInputEvents()
    {
        BindMoveInputEvent();
        BindJumpInputEvent();
        BindAttackInputEvent();
        BindSkillInputEvent();
    }

    private void BindMoveInputEvent()
    {
        Managers.Input.BindInputEvent(Defines.InputType.Move, (_context) =>
        {
            if (_context.performed == true)
            {
                mDirection = _context.ReadValue<Vector2>();
            }
            else if (_context.canceled)
            {
                mDirection = Vector2.zero;
            }

        }, gameObject);
    }

    private void BindJumpInputEvent()
    {
        Managers.Input.BindInputEvent(Defines.InputType.Jump, (_context) =>
        {
            if (_context.performed == true)
                Jump();
        }, gameObject);
    }

    private void BindAttackInputEvent()
    {
        Managers.Input.BindInputEvent(Defines.InputType.Attack, (_context) =>
        {
            if (_context.performed == true)
            {
                Debug.Log("Attack");
            }
        }, gameObject);
    }

    private void BindSkillInputEvent()
    {

    }
}
