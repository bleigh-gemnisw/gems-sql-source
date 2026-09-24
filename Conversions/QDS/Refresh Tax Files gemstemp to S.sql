delete from gemsdtas..TAXCOM where year>0
delete from gemsdtas..TXBAA 
delete from gemsdtas..TXBATCH 
delete from gemsdtas..TXBTR 
delete from gemsdtas..TXBTRC 
delete from gemsdtas..TXCBCH 
delete from gemsdtas..TXCDAG 
delete from gemsdtas..TXCDSF 
delete from gemsdtas..TXCOEA 
delete from gemsdtas..TXCOEB 
delete from gemsdtas..TXCOO 
delete from gemsdtas..TXHST 
delete from gemsdtas..TXINV 
delete from gemsdtas..TXLOCAL 
delete from gemsdtas..TXLOCEX 
delete from gemsdtas..TXLOCFRZ 
delete from gemsdtas..TXM35EX 
delete from gemsdtas..TXM35H 
delete from gemsdtas..TXM35PM 
delete from gemsdtas..TXM59A 
delete from gemsdtas..TXM59PM 
delete from gemsdtas..TXMVA 
delete from gemsdtas..TXMVD 
delete from gemsdtas..TXMVDC 
delete from gemsdtas..TXPPRA 
delete from gemsdtas..TXPPRP 
delete from gemsdtas..TXPPRPC 
delete from gemsdtas..TXPROETB 
delete from gemsdtas..TXPROMS 
delete from gemsdtas..TXPZ 
delete from gemsdtas..TXREAA 
delete from gemsdtas..TXREAL 
delete from gemsdtas..TXREALC 
delete from gemsdtas..TXSUPA 
delete from gemsdtas..TXSUPP 
delete from gemsdtas..TXTRANS 
delete from gemsdtas..TXVBUS 
delete from gemsdtas..TXVCUS 
delete from gemsdtas..TXVEH 
insert into gemsdtas..TAXCOM select * from gemstemp..TAXCOM where year>0
insert into gemsdtas..TXBAA select * from gemstemp..TXBAA
insert into gemsdtas..TXBTR select * from gemstemp..TXBTR
insert into gemsdtas..TXBTRC select * from gemstemp..TXBTRC
insert into gemsdtas..TXCBCH select * from gemstemp..TXCBCH
insert into gemsdtas..TXCDAG select * from gemstemp..TXCDAG
insert into gemsdtas..TXCDSF select * from gemstemp..TXCDSF
insert into gemsdtas..TXCOEA select * from gemstemp..TXCOEA
insert into gemsdtas..TXCOEB select * from gemstemp..TXCOEB
insert into gemsdtas..TXCOO select * from gemstemp..TXCOO
insert into gemsdtas..TXHST select * from gemstemp..TXHST
insert into gemsdtas..TXINV select * from gemstemp..TXINV
insert into gemsdtas..TXLOCAL select * from gemstemp..TXLOCAL
insert into gemsdtas..TXLOCEX select * from gemstemp..TXLOCEX
insert into gemsdtas..TXLOCFRZ select * from gemstemp..TXLOCFRZ
insert into gemsdtas..TXM35EX select * from gemstemp..TXM35EX
insert into gemsdtas..TXM35H select * from gemstemp..TXM35H
insert into gemsdtas..TXM59A select * from gemstemp..TXM59A
insert into gemsdtas..TXMVA select * from gemstemp..TXMVA
insert into gemsdtas..TXMVD select * from gemstemp..TXMVD
insert into gemsdtas..TXMVDC select * from gemstemp..TXMVDC
insert into gemsdtas..TXPPRA select * from gemstemp..TXPPRA
insert into gemsdtas..TXPPRP select * from gemstemp..TXPPRP
insert into gemsdtas..TXPPRPC select * from gemstemp..TXPPRPC
insert into gemsdtas..TXPROETB select * from gemstemp..TXPROETB
insert into gemsdtas..TXPROMS select * from gemstemp..TXPROMS
insert into gemsdtas..TXPZ select * from gemstemp..TXPZ
insert into gemsdtas..TXREAA select * from gemstemp..TXREAA
insert into gemsdtas..TXREAL select * from gemstemp..TXREAL
insert into gemsdtas..TXREALC select * from gemstemp..TXREALC
insert into gemsdtas..TXSUPA select * from gemstemp..TXSUPA
insert into gemsdtas..TXSUPP select * from gemstemp..TXSUPP
insert into gemsdtas..TXTRANS select * from gemstemp..TXTRANS
insert into gemsdtas..TXVBUS select * from gemstemp..TXVBUS
insert into gemsdtas..TXVCUS select * from gemstemp..TXVCUS
insert into gemsdtas..TXVEH select * from gemstemp..TXVEH
