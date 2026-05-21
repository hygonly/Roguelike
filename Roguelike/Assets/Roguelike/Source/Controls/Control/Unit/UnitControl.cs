using UnityEngine;

public abstract class UnitControl : ObjectControl
{
    //HP, 스탯
    //이동 처리
    //피격/사망
    //애니메이션 컨트롤러 연결
    //상태머신 보유
    //스킬 실행 인터페이스

    //PlayerControl
    //
    //입력 받기
    //플레이어 전용 시스템 연결
    //성소 상호작용
    //장비 선택 처리
    //카메라/인벤토리/UI 이벤트 연결

    

    protected UnitAnimationController mAnimControl;

    public override void Initialized()
    {
        
    }
}
