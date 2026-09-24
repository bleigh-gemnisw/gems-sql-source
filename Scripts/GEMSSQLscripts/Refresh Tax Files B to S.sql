delete from gemsdtas..GNET 
delete from gemsdtas..LOGMV 
delete from gemsdtas..LOGPP 
delete from gemsdtas..LOGRE 
delete from gemsdtas..LOGSU 
delete from gemsdtas..LOGUT 
delete from gemsdtas..LOGUTAS 
delete from gemsdtas..LOGUTUS 
delete from gemsdtas..NETGLBCH 
delete from gemsdtas..TAXBCH 
delete from gemsdtas..TAXCOM 
delete from gemsdtas..TBATCH 
delete from gemsdtas..TCRBCH 
delete from gemsdtas..TSPBCH 
delete from gemsdtas..TOWN 
delete from gemsdtas..TXBAA 
delete from gemsdtas..TXBANKS 
delete from gemsdtas..TXBATCH 
delete from gemsdtas..TXBSER 
delete from gemsdtas..TXBTR 
delete from gemsdtas..TXBTRC 
delete from gemsdtas..TXBUSTY 
delete from gemsdtas..TXCBCH 
delete from gemsdtas..TXCDAG 
delete from gemsdtas..TXCDSF 
delete from gemsdtas..TXCNTL 
delete from gemsdtas..TXCODE 
delete from gemsdtas..TXCOEA 
delete from gemsdtas..TXCOEAO 
delete from gemsdtas..TXCOEB 
delete from gemsdtas..TXCOO 
delete from gemsdtas..TXCRESN 
delete from gemsdtas..TXDCAFF 
delete from gemsdtas..TXDCASS 
delete from gemsdtas..TXDCBUS 
delete from gemsdtas..TXDCCD 
delete from gemsdtas..TXDCCOM 
delete from gemsdtas..TXDCDEP 
delete from gemsdtas..TXDCDSP 
delete from gemsdtas..TXDCDTL 
delete from gemsdtas..TXDCEX 
delete from gemsdtas..TXDCEXM 
delete from gemsdtas..TXDCFRM 
delete from gemsdtas..TXDCHOR 
delete from gemsdtas..TXDCLEE 
delete from gemsdtas..TXDCLOR 
delete from gemsdtas..TXDCMOB 
delete from gemsdtas..TXDCMV 
delete from gemsdtas..TXDCPP 
delete from gemsdtas..TXDCSUM 
delete from gemsdtas..TXDCTWN 
delete from gemsdtas..TXDIST 
delete from gemsdtas..TXDMCD 
delete from gemsdtas..TXDMDEP 
delete from gemsdtas..TXDMLES 
delete from gemsdtas..TXDMLST 
delete from gemsdtas..TXDMPP 
delete from gemsdtas..TXDMSUM 
delete from gemsdtas..TXDVAFF 
delete from gemsdtas..TXDVCD 
delete from gemsdtas..TXDVPI 
delete from gemsdtas..TXDVPN 
delete from gemsdtas..TXDVPP 
delete from gemsdtas..TXE08RV 
delete from gemsdtas..TXENDRS 
delete from gemsdtas..TXEXEM 
delete from gemsdtas..TXFMBILL 
delete from gemsdtas..TXFMSTMT 
delete from gemsdtas..TXGL 
delete from gemsdtas..TXGLAD 
delete from gemsdtas..TXGLDA 
delete from gemsdtas..TXGLEL
delete from gemsdtas..TXGLWB
delete from gemsdtas..TXHOIN 
delete from gemsdtas..TXHOME 
delete from gemsdtas..TXHST 
delete from gemsdtas..TXHSTO 
delete from gemsdtas..TXINV 
delete from gemsdtas..TXINVO 
delete from gemsdtas..TXLEASE 
delete from gemsdtas..TXLOCAL 
delete from gemsdtas..TXLOCCD 
delete from gemsdtas..TXLOCEX 
delete from gemsdtas..TXLOCFRZ 
delete from gemsdtas..TXLOCHB 
delete from gemsdtas..TXLOCIN 
delete from gemsdtas..TXM35EX 
delete from gemsdtas..TXM35H 
delete from gemsdtas..TXM35PM 
delete from gemsdtas..TXM37LND 
delete from gemsdtas..TXM59A 
delete from gemsdtas..TXM59PM 
delete from gemsdtas..TXMRATE 
delete from gemsdtas..TXMVA 
delete from gemsdtas..TXMVD 
delete from gemsdtas..TXMVD2 
delete from gemsdtas..TXMVDC 
delete from gemsdtas..TXMVPCT 
delete from gemsdtas..TXNCAM 
delete from gemsdtas..TXOPM 
delete from gemsdtas..TXOWN 
delete from gemsdtas..TXPAYCR 
delete from gemsdtas..TXPAYID 
delete from gemsdtas..TXPEN 
delete from gemsdtas..TXPHIN 
delete from gemsdtas..TXPHINP 
delete from gemsdtas..TXPHINR 
delete from gemsdtas..TXPPRA 
delete from gemsdtas..TXPPRP 
delete from gemsdtas..TXPPRPC 
delete from gemsdtas..TXPROETB 
delete from gemsdtas..TXPROF 
delete from gemsdtas..TXPROMS 
delete from gemsdtas..TXPZ 
delete from gemsdtas..TXREAA 
delete from gemsdtas..TXREAL 
delete from gemsdtas..TXREALC 
delete from gemsdtas..TXSRESN 
delete from gemsdtas..TXSTS 
delete from gemsdtas..TXSUPA 
delete from gemsdtas..TXSUPCD 
delete from gemsdtas..TXSUPP 
delete from gemsdtas..TXSUPP2 
delete from gemsdtas..TXTRANS 
delete from gemsdtas..TXTYPE 
delete from gemsdtas..TXVBUS 
delete from gemsdtas..TXVCLS 
delete from gemsdtas..TXVCUS 
delete from gemsdtas..TXVEH 
delete from gemsdtas..TXXPROP 
delete from gemsdtas..TXZIP 
delete from gemsdtas..UTBLHS 
delete from gemsdtas..UTBREAK 
delete from gemsdtas..UTCRESN 
delete from gemsdtas..UTCNTL 
delete from gemsdtas..UTCOEA 
delete from gemsdtas..UTCUST 
delete from gemsdtas..UTCUSTAS 
delete from gemsdtas..UTCUSTMT 
delete from gemsdtas..UTCUSTRT 
delete from gemsdtas..UTDIST 
delete from gemsdtas..UTFMBILL 
delete from gemsdtas..UTMETER 
delete from gemsdtas..UTMRESN 
delete from gemsdtas..UTRATEAS 
delete from gemsdtas..UTRATEMT 
delete from gemsdtas..UTRATEUS 
delete from gemsdtas..UTTYPE 
delete from gemsdtas..UTXREF 
insert into gemsdtas..GNET select * from gemsdtab..GNET
insert into gemsdtas..LOGMV select * from gemsdtab..LOGMV
insert into gemsdtas..LOGPP select * from gemsdtab..LOGPP
insert into gemsdtas..LOGRE select * from gemsdtab..LOGRE
insert into gemsdtas..LOGSU select * from gemsdtab..LOGSU
insert into gemsdtas..LOGUT select * from gemsdtab..LOGUT
insert into gemsdtas..LOGUTAS select * from gemsdtab..LOGUTAS
insert into gemsdtas..LOGUTUS select * from gemsdtab..LOGUTUS
insert into gemsdtas..NETGLBCH select * from gemsdtab..NETGLBCH
insert into gemsdtas..TAXBCH select * from gemsdtab..TAXBCH
insert into gemsdtas..TAXCOM select * from gemsdtab..TAXCOM
insert into gemsdtas..TBATCH select * from gemsdtab..TBATCH
insert into gemsdtas..TCRBCH select * from gemsdtab..TCRBCH
insert into gemsdtas..TSPBCH select * from gemsdtab..TSPBCH
insert into gemsdtas..TOWN select * from gemsdtab..TOWN
insert into gemsdtas..TXBAA select * from gemsdtab..TXBAA
insert into gemsdtas..TXBANKS select * from gemsdtab..TXBANKS
insert into gemsdtas..TXBATCH select * from gemsdtab..TXBATCH
insert into gemsdtas..TXBSER select * from gemsdtab..TXBSER
insert into gemsdtas..TXBTR select * from gemsdtab..TXBTR
insert into gemsdtas..TXBTRC select * from gemsdtab..TXBTRC
insert into gemsdtas..TXBUSTY select * from gemsdtab..TXBUSTY
insert into gemsdtas..TXCBCH select * from gemsdtab..TXCBCH
insert into gemsdtas..TXCDAG select * from gemsdtab..TXCDAG
insert into gemsdtas..TXCDSF select * from gemsdtab..TXCDSF
insert into gemsdtas..TXCNTL select * from gemsdtab..TXCNTL
insert into gemsdtas..TXCODE select * from gemsdtab..TXCODE
insert into gemsdtas..TXCOEA select * from gemsdtab..TXCOEA
insert into gemsdtas..TXCOEAO select * from gemsdtab..TXCOEAO
insert into gemsdtas..TXCOEB select * from gemsdtab..TXCOEB
insert into gemsdtas..TXCOO select * from gemsdtab..TXCOO
insert into gemsdtas..TXCRESN select * from gemsdtab..TXCRESN
insert into gemsdtas..TXDCAFF select * from gemsdtab..TXDCAFF
insert into gemsdtas..TXDCASS select * from gemsdtab..TXDCASS
insert into gemsdtas..TXDCBUS select * from gemsdtab..TXDCBUS
insert into gemsdtas..TXDCCD select * from gemsdtab..TXDCCD
insert into gemsdtas..TXDCCOM select * from gemsdtab..TXDCCOM
insert into gemsdtas..TXDCDEP select * from gemsdtab..TXDCDEP
insert into gemsdtas..TXDCDSP select * from gemsdtab..TXDCDSP
insert into gemsdtas..TXDCDTL select * from gemsdtab..TXDCDTL
insert into gemsdtas..TXDCEX select * from gemsdtab..TXDCEX
insert into gemsdtas..TXDCEXM select * from gemsdtab..TXDCEXM
insert into gemsdtas..TXDCFRM select * from gemsdtab..TXDCFRM
insert into gemsdtas..TXDCHOR select * from gemsdtab..TXDCHOR
insert into gemsdtas..TXDCLEE select * from gemsdtab..TXDCLEE
insert into gemsdtas..TXDCLOR select * from gemsdtab..TXDCLOR
insert into gemsdtas..TXDCMOB select * from gemsdtab..TXDCMOB
insert into gemsdtas..TXDCMV select * from gemsdtab..TXDCMV
insert into gemsdtas..TXDCPP select * from gemsdtab..TXDCPP
insert into gemsdtas..TXDCSUM select * from gemsdtab..TXDCSUM
insert into gemsdtas..TXDCTWN select * from gemsdtab..TXDCTWN
insert into gemsdtas..TXDIST select * from gemsdtab..TXDIST
insert into gemsdtas..TXDMCD select * from gemsdtab..TXDMCD
insert into gemsdtas..TXDMDEP select * from gemsdtab..TXDMDEP
insert into gemsdtas..TXDMLES select * from gemsdtab..TXDMLES
insert into gemsdtas..TXDMLST select * from gemsdtab..TXDMLST
insert into gemsdtas..TXDMPP select * from gemsdtab..TXDMPP
insert into gemsdtas..TXDMSUM select * from gemsdtab..TXDMSUM
insert into gemsdtas..TXDVAFF select * from gemsdtab..TXDVAFF
insert into gemsdtas..TXDVCD select * from gemsdtab..TXDVCD
insert into gemsdtas..TXDVPI select * from gemsdtab..TXDVPI
insert into gemsdtas..TXDVPN select * from gemsdtab..TXDVPN
insert into gemsdtas..TXDVPP select * from gemsdtab..TXDVPP
insert into gemsdtas..TXENDRS select * from gemsdtab..TXENDRS
insert into gemsdtas..TXEXEM select * from gemsdtab..TXEXEM
insert into gemsdtas..TXFMBILL select * from gemsdtab..TXFMBILL
insert into gemsdtas..TXFMSTMT select * from gemsdtab..TXFMSTMT
insert into gemsdtas..TXHOIN select * from gemsdtab..TXHOIN
insert into gemsdtas..TXHOME select * from gemsdtab..TXHOME
insert into gemsdtas..TXHST select * from gemsdtab..TXHST
insert into gemsdtas..TXHSTO select * from gemsdtab..TXHSTO
insert into gemsdtas..TXINV select * from gemsdtab..TXINV
insert into gemsdtas..TXINVO select * from gemsdtab..TXINVO
insert into gemsdtas..TXLEASE select * from gemsdtab..TXLEASE
insert into gemsdtas..TXLOCAL select * from gemsdtab..TXLOCAL
insert into gemsdtas..TXLOCCD select * from gemsdtab..TXLOCCD
insert into gemsdtas..TXLOCFRZ select * from gemsdtab..TXLOCFRZ
insert into gemsdtas..TXM35EX select * from gemsdtab..TXM35EX
insert into gemsdtas..TXM35H select * from gemsdtab..TXM35H
insert into gemsdtas..TXM37LND select * from gemsdtab..TXM37LND
insert into gemsdtas..TXM59A select * from gemsdtab..TXM59A
insert into gemsdtas..TXMRATE select * from gemsdtab..TXMRATE
insert into gemsdtas..TXMVA select * from gemsdtab..TXMVA
insert into gemsdtas..TXMVD select * from gemsdtab..TXMVD
insert into gemsdtas..TXMVD2 select * from gemsdtab..TXMVD2
insert into gemsdtas..TXMVDC select * from gemsdtab..TXMVDC
insert into gemsdtas..TXMVPCT select * from gemsdtab..TXMVPCT
insert into gemsdtas..TXNCAM select * from gemsdtab..TXNCAM
insert into gemsdtas..TXOPM select * from gemsdtab..TXOPM
insert into gemsdtas..TXOWN select * from gemsdtab..TXOWN
insert into gemsdtas..TXPAYCR select * from gemsdtab..TXPAYCR
insert into gemsdtas..TXPAYID select * from gemsdtab..TXPAYID
insert into gemsdtas..TXPEN select * from gemsdtab..TXPEN
insert into gemsdtas..TXPPRA select * from gemsdtab..TXPPRA
insert into gemsdtas..TXPPRP select * from gemsdtab..TXPPRP
insert into gemsdtas..TXPPRPC select * from gemsdtab..TXPPRPC
insert into gemsdtas..TXPROETB select * from gemsdtab..TXPROETB
insert into gemsdtas..TXPROF select * from gemsdtab..TXPROF
insert into gemsdtas..TXPROMS select * from gemsdtab..TXPROMS
insert into gemsdtas..TXPZ select * from gemsdtab..TXPZ
insert into gemsdtas..TXREAA select * from gemsdtab..TXREAA
insert into gemsdtas..TXREAL select * from gemsdtab..TXREAL
insert into gemsdtas..TXREALC select * from gemsdtab..TXREALC
insert into gemsdtas..TXSRESN select * from gemsdtab..TXSRESN
insert into gemsdtas..TXSTS select * from gemsdtab..TXSTS
insert into gemsdtas..TXSUPA select * from gemsdtab..TXSUPA
insert into gemsdtas..TXSUPCD select * from gemsdtab..TXSUPCD
insert into gemsdtas..TXSUPP select * from gemsdtab..TXSUPP
insert into gemsdtas..TXSUPP2 select * from gemsdtab..TXSUPP2
insert into gemsdtas..TXTRANS select * from gemsdtab..TXTRANS
insert into gemsdtas..TXTYPE select * from gemsdtab..TXTYPE
insert into gemsdtas..TXVBUS select * from gemsdtab..TXVBUS
insert into gemsdtas..TXVCLS select * from gemsdtab..TXVCLS
insert into gemsdtas..TXVCUS select * from gemsdtab..TXVCUS
insert into gemsdtas..TXVEH select * from gemsdtab..TXVEH
insert into gemsdtas..TXXPROP select * from gemsdtab..TXXPROP
insert into gemsdtas..TXZIP select * from gemsdtab..TXZIP
insert into gemsdtas..UTBLHS select * from gemsdtab..UTBLHS
insert into gemsdtas..UTBREAK select * from gemsdtab..UTBREAK
insert into gemsdtas..UTCNTL select * from gemsdtab..UTCNTL
insert into gemsdtas..UTCOEA select * from gemsdtab..UTCOEA
insert into gemsdtas..UTCRESN select * from gemsdtab..UTCRESN
insert into gemsdtas..UTCUST select * from gemsdtab..UTCUST
insert into gemsdtas..UTCUSTAS select * from gemsdtab..UTCUSTAS
insert into gemsdtas..UTCUSTMT select * from gemsdtab..UTCUSTMT
insert into gemsdtas..UTCUSTRT select * from gemsdtab..UTCUSTRT
insert into gemsdtas..UTDIST select * from gemsdtab..UTDIST
insert into gemsdtas..UTFMBILL select * from gemsdtab..UTFMBILL
insert into gemsdtas..UTMETER select * from gemsdtab..UTMETER
insert into gemsdtas..UTMRESN select * from gemsdtab..UTMRESN
insert into gemsdtas..UTRATEAS select * from gemsdtab..UTRATEAS
insert into gemsdtas..UTRATEMT select * from gemsdtab..UTRATEMT
insert into gemsdtas..UTRATEUS select * from gemsdtab..UTRATEUS
insert into gemsdtas..UTTYPE select * from gemsdtab..UTTYPE
insert into gemsdtas..UTXREF select * from gemsdtab..UTXREF
insert into gemsdtas..TXGL select * from gemsdtab..TXGL
insert into gemsdtas..TXGLAD select * from gemsdtab..TXGLAD
insert into gemsdtas..TXGLDA select * from gemsdtab..TXGLDA
insert into gemsdtas..TXGLEL select * from gemsdtab..TXGLEL
insert into gemsdtas..TXGLWB select * from gemsdtab..TXGLWB
insert into gemsdtas..TXE08RV select * from gemsdtab..TXE08RV
insert into gemsdtas..TXLOCEX select * from gemsdtab..TXLOCEX
insert into gemsdtas..TXPHIN select * from gemsdtab..TXPHIN
insert into gemsdtas..TXPHINP select * from gemsdtab..TXPHINP
insert into gemsdtas..TXPHINR select * from gemsdtab..TXPHINR
insert into gemsdtas..TXLOCHB select * from gemsdtab..TXLOCHB
insert into gemsdtas..TXLOCIN select * from gemsdtab..TXLOCIN
insert into gemsdtas..TXM35PM select * from gemsdtab..TXM35PM
insert into gemsdtas..TXM59PM select * from gemsdtab..TXM59PM
