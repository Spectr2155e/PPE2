create table users
(
    ID            int  not null
        primary key,
    USER_NAME     text null,
    USER_PASSWORD text null,
    CREATION_DATE date null
);

INSERT INTO cpumarket.users (ID, USER_NAME, USER_PASSWORD, CREATION_DATE) VALUES (0, 'Spectr2155e', 'a0bad0e50d5a4dc1955a28f30992db6f9e7eb6bc13fa33336e338d18fcec661e', '2024-10-17');
