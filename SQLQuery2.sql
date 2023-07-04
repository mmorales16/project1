  CREATE TABLE dbo.Roles
        (
            id int identity(1,1) primary key,
            Description varchar(15)
        );

         CREATE TABLE dbo.RolesUsuario
        (
            id int identity(1,1) primary key,
            id_role int not null,
            id_user int not null,

        );

        INSERT INTO Roles VALUES ('ADMIN');
        INSERT INTO Roles VALUES ('OTROS');


        INSERT INTO dbo.RolesUsuario (id_role, id_user) VALUES (1, 21);

        select * from Roles;
        select * from RolesUsuario;

        DELETE FROM dbo.RolesUsuario
WHERE id = 2;