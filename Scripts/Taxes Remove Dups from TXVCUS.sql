select * iNTO TXVCUS220425 FROM TXVCUS
go
delete from txvcus
go
insert into txvcus select distinct * from TXVCUS220425 
go