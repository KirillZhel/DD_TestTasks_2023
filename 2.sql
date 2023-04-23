--2) Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева).
with rec as (
	-- anchor part
      select ID, chief_id, name, depth = 0
      from EMPLOYEE
      where chief_id is null

      union ALL
	-- recursive part
      select EMPLOYEE.ID, EMPLOYEE.chief_id, EMPLOYEE.[NAME], depth = rec.depth + 1
      from rec
      INNER JOIN EMPLOYEE on rec.ID = EMPLOYEE.chief_id
)
select MAX(depth)
from rec;