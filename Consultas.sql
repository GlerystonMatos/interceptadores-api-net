SELECT * FROM Interceptadores.dbo.Animal
SELECT * FROM Interceptadores.dbo.Usuario

SELECT * FROM InterceptadoresAuditoria.dbo.EntityAudit
SELECT * FROM InterceptadoresAuditoria.dbo.SaveChangesAudit

SELECT * FROM Interceptadores01.dbo.Animal
SELECT * FROM Interceptadores01.dbo.Usuario

SELECT * FROM InterceptadoresAuditoria01.dbo.EntityAudit
SELECT * FROM InterceptadoresAuditoria01.dbo.SaveChangesAudit

SELECT e.Id, e.State, e.AuditMessage, s.StartTime, s.Succeeded
  FROM InterceptadoresAuditoria.dbo.EntityAudit e
 INNER JOIN InterceptadoresAuditoria.dbo.SaveChangesAudit s ON s.Id = e.SaveChangesAuditId
 ORDER BY s.StartTime

 SELECT e.Id, e.State, e.AuditMessage, s.StartTime, s.Succeeded
  FROM InterceptadoresAuditoria01.dbo.EntityAudit e
 INNER JOIN InterceptadoresAuditoria01.dbo.SaveChangesAudit s ON s.Id = e.SaveChangesAuditId
 ORDER BY s.StartTime