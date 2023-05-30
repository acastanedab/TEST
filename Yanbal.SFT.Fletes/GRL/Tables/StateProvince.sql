CREATE TABLE [GRL].[StateProvince] (
    [Code]           NVARCHAR (255) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Country]        CHAR (2)       NOT NULL,
    [Id]             INT            NOT NULL,
    [ZoneCode]       NVARCHAR (10)  NULL,
    [ParentZoneCode] NVARCHAR (10)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de StateProvince.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Name.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Country.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'Country';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'ZoneCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parent Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'StateProvince', @level2type = N'COLUMN', @level2name = N'ParentZoneCode';

