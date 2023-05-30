CREATE TABLE [GRL].[City] (
    [Name]           NVARCHAR (255) NOT NULL,
    [Id]             INT            NOT NULL,
    [PostalCode]     INT            NULL,
    [ZoneCode]       NVARCHAR (10)  NULL,
    [ParentZoneCode] NVARCHAR (10)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de City.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Name.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Postal Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City', @level2type = N'COLUMN', @level2name = N'PostalCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City', @level2type = N'COLUMN', @level2name = N'ZoneCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parent Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'City', @level2type = N'COLUMN', @level2name = N'ParentZoneCode';

