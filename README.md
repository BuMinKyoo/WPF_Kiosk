
# WPF Kiosk Demo

## 프로젝트 소개
WPF 기반 Kiosk 프로그램 데모입니다.  
- MVVM 패턴 적용
- Microsoft.Extensions.DependencyInjection으로 의존성 주입(DI) 구조
- WeakReferenceMessenger로 ViewModel 간 통신
- XAML CommandBehavior : 직접 이벤트 → ICommand 트리거
- Multi ViewModel Injection 및 Dynamic DataContext

## 기술 스택
- C#, WPF, MVVM
- CommunityToolkit.Mvvm
- Microsoft.Extensions.DependencyInjection
- XAML CommandBehavior

## 주요 기능
- 메인화면, 관리자 화면, 상품 상세/확인 화면 등 다양한 View 구성
- XAML에서 SizeChanged → CommandBehavior를 통한 Command 직접 실행
- 관리자 화면 3회 클릭시 진입 + DispatcherTimer로 카운트 초기화
- ViewModel 간 Event 메시지 전달로 상태 변경

https://github.com/BuMinKyoo/WPF_Kiosk/assets/39178978/d5ec6fdc-637f-4fd4-8829-91bb8612d7b5

<br/>
<br/>

https://github.com/BuMinKyoo/WPF_Kiosk/assets/39178978/4c3dc79d-24a4-4d95-ae28-2d76c98a04f0

