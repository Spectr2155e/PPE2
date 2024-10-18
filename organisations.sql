create table organisations
(
    ID               int auto_increment
        primary key,
    NAME             text      null,
    CREATION_DATE    timestamp null,
    DESCRIPTION      text      null,
    PERMISSION_LEVEL int       null
);

INSERT INTO ppe2.organisations (ID, NAME, CREATION_DATE, DESCRIPTION, PERMISSION_LEVEL) VALUES (1, 'Administrateur', '2024-10-18 14:26:24', 'Les administrateurs de l\'application', 4);
INSERT INTO ppe2.organisations (ID, NAME, CREATION_DATE, DESCRIPTION, PERMISSION_LEVEL) VALUES (2, 'Google', '2024-10-18 14:26:46', 'Les employés de Google', 2);
INSERT INTO ppe2.organisations (ID, NAME, CREATION_DATE, DESCRIPTION, PERMISSION_LEVEL) VALUES (3, 'Microsoft', '2024-10-18 14:27:13', 'Les employés de Microsoft', 1);
