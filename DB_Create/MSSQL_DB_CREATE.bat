@echo off

:: MSSQL Server 서비스 시작 명령을 실행합니다.
net start mssqlserver

:: 배치 파일이 있는 폴더를 현재 작업 디렉토리로 설정합니다.
cd /d "%~dp0"

:: SQL Server 연결 정보
set ServerAddress=(local)
set Username=qnalsrb
set Password=1111
set DatabaseName=JM_KioskDatabase

:: 데이터베이스 생성
echo Creating Database...
sqlcmd -S %ServerAddress% -U %Username% -P %Password% -i "CreateJM_KioskDatabase.sql"
echo Database created successfully.

:: 테이블 생성
echo Creating table...
sqlcmd -S %ServerAddress% -d %DatabaseName% -U %Username% -P %Password% -i "CreateJM_KioskTable.sql"
echo table created successfully.

:: 데이터 인설트
echo Creating uqdate...
sqlcmd -S %ServerAddress% -d %DatabaseName% -U %Username% -P %Password% -i "CreateJM_KioskInsert.sql"
echo uqdate created successfully.

pause