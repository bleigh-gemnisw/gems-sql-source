select txinv.list#,txinv.type,txinv.year,name,pcamt,comm from txinv
INNER JOIN TXhst ON TXINV.LIST# = TXhst.LIST# and TXINV.TYPE = TXhst.type and TXINV.year = TXhst.year
where icode='S' and susdt=20130513 and rcode='I'
order by comm,name
