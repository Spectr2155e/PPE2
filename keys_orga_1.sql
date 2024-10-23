create table keys_orga
(
    ID              int auto_increment
        primary key,
    KEY_STRING      text null,
    ORGANISATION_ID int  null
);

INSERT INTO ppe2.keys_orga (ID, KEY_STRING, ORGANISATION_ID) VALUES (1, 'HUuHXILF1b9UiRHqQzic', 1);
