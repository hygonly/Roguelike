using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace HYG.Manager.Time
{

    public class TimeManager : HYG.Manager.Base.SlaveManager
    {
        public float DeltaTime { get { return UnityEngine.Time.deltaTime * mGameSpeed; } }
        private float mGameSpeed;
        
        private List<Func<bool>> mTenSecondsIntervalActions = new List<Func<bool>>();
        private List<Func<bool>> mOneMinutesIntervalActions = new List<Func<bool>>();
        private List<Func<bool>> mFiveMinutesIntervalActions = new List<Func<bool>>();
        private List<Func<bool>> mRemoveActions = new List<Func<bool>>();

        protected override void Init()
        {
            base.Init();

            Observable.Interval(TimeSpan.FromSeconds(10)).Subscribe(_ => { HandleIntervalActions(mTenSecondsIntervalActions); });
            Observable.Interval(TimeSpan.FromSeconds(60)).Subscribe(_ => { HandleIntervalActions(mOneMinutesIntervalActions); });
            Observable.Interval(TimeSpan.FromSeconds(300)).Subscribe(_ => { HandleIntervalActions(mFiveMinutesIntervalActions); });
        }

        public void RegisterTenSecondsAction(Func<bool> action, GameObject dispose = null)
        {
            mTenSecondsIntervalActions.Add(action);
            dispose?.OnDestroyAsObservable().Subscribe(_ =>
            {
                mTenSecondsIntervalActions.Remove(action);
            });
        }

        public void RegisterOneMinutesAction(Func<bool> action, GameObject dispose = null)
        {
            mOneMinutesIntervalActions.Add(action);
            dispose?.OnDestroyAsObservable().Subscribe(_ =>
            {
                mOneMinutesIntervalActions.Remove(action);
            });
        }

        public void RegisterFiveMinutesAction(Func<bool> action, GameObject dispose = null)
        {
            mFiveMinutesIntervalActions.Add(action);
            dispose?.OnDestroyAsObservable().Subscribe(_ =>
            {
                mFiveMinutesIntervalActions.Remove(action);
            });
        }

        private void HandleIntervalActions(List<Func<bool>> actions)
        {
            foreach (var action in actions)
            {
                if (action != null && action.Invoke() == false)
                    mRemoveActions.Add(action);
            }

            foreach (var action in mRemoveActions)
                actions.Remove(action);
            mRemoveActions.Clear();
        }
    }
}