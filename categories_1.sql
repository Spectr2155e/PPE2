create table categories
(
    ID   int auto_increment
        primary key,
    NAME text null
);

INSERT INTO ppe2.categories (ID, NAME) VALUES (1, 'Meubles');
INSERT INTO ppe2.categories (ID, NAME) VALUES (2, 'Matériaux');
INSERT INTO ppe2.categories (ID, NAME) VALUES (3, 'Composants informatiques');
INSERT INTO ppe2.categories (ID, NAME) VALUES (4, 'Matières premieres');
INSERT INTO ppe2.categories (ID, NAME) VALUES (5, 'Colis');
