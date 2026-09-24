select * iNTO TAXCOM220425 FROM TAXCOM
go
delete from taxcom
go
insert into taxcom select distinct * from TAXCOM220425 
go