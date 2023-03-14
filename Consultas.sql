SELECT * FROM Interceptadores.dbo.Animal
SELECT * FROM Interceptadores.dbo.Usuario

SELECT * FROM InterceptadoresAuditoria.dbo.EntityAudit
SELECT * FROM InterceptadoresAuditoria.dbo.SaveChangesAudit

SELECT e.Id, e.State, e.AuditMessage, s.StartTime, s.Succeeded
  FROM InterceptadoresAuditoria.dbo.EntityAudit e
 INNER JOIN InterceptadoresAuditoria.dbo.SaveChangesAudit s ON s.Id = e.SaveChangesAuditId
 ORDER BY s.StartTime