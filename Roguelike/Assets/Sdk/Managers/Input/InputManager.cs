using HYG.Manager.Base;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HYG.Manager.Input
{
    public abstract class InputManager : SlaveManager
    {
        protected Dictionary<Defines.InputType, InputAction> mInputActions = new Dictionary<Defines.InputType, InputAction>();
        protected Dictionary<Defines.InputType, List<Subject<InputAction.CallbackContext>>> mInputCallbacks = new();

        protected override void Init()
        {
            
        }

        public abstract void LoadInputDatas();
        protected abstract void OnInputAction(Defines.InputType _inputType, InputAction.CallbackContext _context);

        public virtual bool BindInputEvent(Defines.InputType _inputType, Action<InputAction.CallbackContext> _action, GameObject _dispose)
        {
            if (mInputActions.TryGetValue(_inputType, out var inputAction) == false)
                return false;

            if (mInputCallbacks.TryGetValue(_inputType, out var actions) == false)
                return false;

            var subject = new Subject<InputAction.CallbackContext>();
            subject.Subscribe(_action).AddTo(_dispose);
            actions.Add(subject);
            return true;
        }
    }
}