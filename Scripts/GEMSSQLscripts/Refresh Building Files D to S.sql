delete from BDCNTL
delete from BDCOM
delete from BDCON
delete from BDENDRS
delete from BDMAST
delete from BDPAYCR
delete from BDRATE
insert into BDCNTL select * from gemsdtad..BDCNTL
insert into BDCOM select * from gemsdtad..BDCOM
insert into BDCON select * from gemsdtad..BDCON
insert into BDENDRS select * from gemsdtad..BDENDRS
insert into BDMAST select * from gemsdtad..BDMAST
insert into BDPAYCR select * from gemsdtad..BDPAYCR
insert into BDRATE select * from gemsdtad..BDRATE
