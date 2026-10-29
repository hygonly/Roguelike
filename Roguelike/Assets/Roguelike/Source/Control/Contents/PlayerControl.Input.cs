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

    }

    private void BindAttackInputEvent()
    {

    }

    private void BindSkillInputEvent()
    {

    }
}
