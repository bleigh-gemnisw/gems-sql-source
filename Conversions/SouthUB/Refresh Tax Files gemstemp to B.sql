delete from gemsdtab..TAXCOM where year>0
delete from gemsdtab..TXHST 
delete from gemsdtab..TXINV 
insert into gemsdtab..TAXCOM select * from gemstemp..TAXCOM where year>0
insert into gemsdtab..TXHST select * from gemstemp..TXHST
insert into gemsdtab..TXINV select * from gemstemp..TXINV
