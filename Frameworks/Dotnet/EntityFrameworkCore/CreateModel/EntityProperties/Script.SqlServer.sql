CREATE VIEW [CreateModelDemo].[FulltimeStuentView] AS SELECT [StudentName], len([StudentName]) len_name  FROM [CreateModelDemo].[T_Student] WHERE [Courses]>2;
GO

CREATE FUNCTION [CreateModelDemo].FulltimeStudentFunction()
RETURNS TABLE AS RETURN
(
    SELECT [StudentName], len([StudentName]) len_name FROM [CreateModelDemo].[T_Student] WHERE [Courses]>2
);
Go