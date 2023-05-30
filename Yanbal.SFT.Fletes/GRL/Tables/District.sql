CREATE TABLE [GRL].[District] (
    [Id]             INT            NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [ZoneCode]       NVARCHAR (10)  NULL,
    [ParentZoneCode] NVARCHAR (10)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de District.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'District';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'District', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Name.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'District', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'District', @level2type = N'COLUMN', @level2name = N'ZoneCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parent Zone Code.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'District', @level2type = N'COLUMN', @level2name = N'ParentZoneCode';

