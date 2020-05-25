# Unity_UnitTestTester
유니티 라이브러리의 테스트 함수를 대신 실행해주는 유니티 프로젝트입니다.\

## 테스트하는 저장소 목록
| Plugin | COMMENT | LINK |
| ------ | ------ | ------ |
| <b>GetComponent Attribute</b> | Unity GetComponent를 Attribute를 통해 사용할 수 있는 플러그인입니다.| [https://github.com/KorStrix/Unity_GetComponentAttribute](https://github.com/KorStrix/Unity_GetComponentAttribute) |
| <b>Jenkins Builder</b> | 외부 CI툴에서 유니티 빌드 자동화를 하기 위한 플러그인입니다. | [https://github.com/KorStrix/Unity_JenkinsBuilder](https://github.com/KorStrix/Unity_JenkinsBuilder) |
| <b>UI Framework</b> | 유니티 UGUI 기반의 프레임워크입니다. | [https://github.com/KorStrix/Unity_UIFramework](https://github.com/KorStrix/Unity_UIFramework) |
| <b>Unity Pattern</b> | 유니티에서 자주 사용하는 패턴 모음입니다. | [https://github.com/KorStrix/Unity_Pattern](https://github.com/KorStrix/Unity_Pattern.git) |

---
## 현재 문제점
본래 각 저장소에서 하는 것이 정상이나,\
다음과 같은 문제점때문에 저장소를 따로 두었습니다.\

1. 유니티 테스트 함수의 경우 유니티 프로젝트 내에서 실행해야만 합니다.\
그러나 Unity Package 형태의 저장소의 경우 루트폴더의 양식이 Unity Package 양식을 따라야 합니다.\
\

2. 1번 사항때문에 2가지 방법으로 해결해야 했습니다.\
2-1. Unity Package 안에 Sample Unity Project를 두고 또 그 안에 Package를 둔 형태\
- 이 형태가 이상적이나, Github Action에서 같은 저장소 내 다른 경로로 카피&커밋을 찾지 못했습니다(20.05기준)\
\
2-2. Unity Package 저장소는 Package만 두되, 테스트만 실행하는 Unity Project를 따로 두어 거기에 커밋 후 테스트를 실행하는 형태\
- 현재 2-1 방법을 찾지 못해서 이 방법으로 하고 있습니다.\


---
## 개선사항
- 테스트 실행 결과가 직관적이지 않습니다. 현재 <b>GithubAction - webbertakken/unity-test-runner</b>를 통해 하고 있는데, 좀 더 R&D를 해야 합니다.\
링크 : https://github.com/webbertakken/unity-actions

- 현재 문제점란에 중 2-1 방법으로 다시 바꾸는 것이 이상적입니다.
