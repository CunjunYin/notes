CREATE VIEW [CreateModelDemo].[FulltimeStuentView] AS SELECT [Name], len([Name]) NameLength  FROM [CreateModelDemo].[T_Student] WHERE [Courses]>2;
GO

CREATE FUNCTION [CreateModelDemo].FulltimeStudentFunction()
RETURNS TABLE AS RETURN
(
    SELECT [Name], len([Name]) NameLength FROM [CreateModelDemo].[T_Student] WHERE [Courses]>2
);
Go