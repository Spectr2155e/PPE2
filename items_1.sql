create table items
(
    ID              int auto_increment
        primary key,
    NAME            text      null,
    QUANTITY        int       null,
    WEIGHT          double    null,
    ADDING_DATE     timestamp null,
    CATEGORY_ID     int       null,
    ORGANISATION_ID int       null
);

INSERT INTO ppe2.items (ID, NAME, QUANTITY, WEIGHT, ADDING_DATE, CATEGORY_ID, ORGANISATION_ID) VALUES (5, 'trest', 2, 2, '2024-10-20 22:00:04', 3, 1);
