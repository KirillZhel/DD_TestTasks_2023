--3) Отдел, с максимальной суммарной зарплатой сотрудников.
SELECT D.ID, D.Name, SUM(salary) as SUMSALARY
FROM DEPARTMENT AS D 
  JOIN EMPLOYEE AS E 
    ON D.ID = E.DEPARTMENT_ID
GROUP BY d.ID, d.name
HAVING SUM(salary) >= ALL(SELECT SUM(salary) from EMPLOYEE GROUP by department_id);