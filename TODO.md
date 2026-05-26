# TODO

## GitHub 설정

- [ ] PR 템플릿 추가 — `.github/PULL_REQUEST_TEMPLATE.md`
  - 구조: 목표 / 변경 내용 / 다음 작업(TODO)
- [ ] Issue 템플릿 추가 — `.github/ISSUE_TEMPLATE/`
  - bug_report.md
  - feature_request.md

## AbilitySystem

- [ ] `AttributeCurrentValue` 계산 방식 결정
  - 현재: `AttributeData.CurrentValue`를 직접 저장
  - 선택지
    - **recalculate-on-read**: `GetAttributeCurrentValue` 호출 시 `BaseValue + Σ ActiveEffect Modifier` 즉석 계산 — 항상 정확하지만 호출 빈도가 높으면 비용 발생
    - **dirty-on-write**: Effect 적용/해제 시점에 `CurrentValue` 갱신 후 저장 — 읽기 비용 없지만 Effect 관리가 복잡해짐