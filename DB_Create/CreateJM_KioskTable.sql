-- 테이블이 이미 존재하는 경우 삭제합니다.
IF OBJECT_ID('MLOGINTB', 'U') IS NOT NULL
    DROP TABLE MLOGINTB;

-- 테이블을 생성합니다.
CREATE TABLE MLOGINTB (
    UserName NVARCHAR(255),
    Password NVARCHAR(255),
    PRIMARY KEY (UserName)
);