IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE TABLE [Students] (
        [Id] int NOT NULL IDENTITY,
        [sbd] nvarchar(max) NULL,
        [toan] float NULL,
        [ngu_van] float NULL,
        [ngoai_ngu] float NULL,
        [vat_li] float NULL,
        [hoa_hoc] float NULL,
        [sinh_hoc] float NULL,
        [lich_su] float NULL,
        [dia_li] float NULL,
        [gdcd] float NULL,
        [ma_ngoai_ngu] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_dia_li] ON [Students] ([dia_li]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_gdcd] ON [Students] ([gdcd]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_hoa_hoc] ON [Students] ([hoa_hoc]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_lich_su] ON [Students] ([lich_su]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_ngoai_ngu] ON [Students] ([ngoai_ngu]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_ngu_van] ON [Students] ([ngu_van]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_sinh_hoc] ON [Students] ([sinh_hoc]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_toan] ON [Students] ([toan]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Students_vat_li] ON [Students] ([vat_li]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241125162433_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241125162433_InitialCreate', N'9.0.0');
END;

COMMIT;
GO

