using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : HYG.Manager.Input.InputManager
{
    public override void LoadInputDatas()
    {
        var enumValues = typeof(Defines.InputType).GetEnumNames();
        var actionAsset = ProjectSettingScriptableObject.Instance.InputAsset;
        for (var i = 0; i < enumValues.Length; i++)
        {
            Defines.InputType inputType = (Defines.InputType)i;
            if (inputType == Defines.InputType.None)
                continue;

            var enumName = enumValues[i];
            mInputActions[inputType] = actionAsset.FindAction($"Player/{enumName}", true);
            mInputCallbacks[inputType] = new List<Subject<InputAction.CallbackContext>>();

            var action = mInputActions[inputType];
            action.started += context => OnInputAction(inputType, context);
            action.performed += context => OnInputAction(inputType, context);
            action.canceled += context => OnInputAction(inputType, context);
        }

        actionAsset.Enable();
    }

    protected override void OnInputAction(Defines.InputType _inputType, InputAction.CallbackContext _context)
    {
        var subjects = mInputCallbacks[_inputType];
        foreach (var subject in subjects)
            subject.OnNext(_context);
    }
}
