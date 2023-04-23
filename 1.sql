--1) Сотрудника с максимальной заработной платой.
SELECT TOP 1 * from EMPLOYEE where salary = (SELECT MAX(salary) from EMPLOYEE);