SELECT  txinv.LIST#, txinv.type, txinv.year, txinv.NAME, CCETAX, TXCOea.CETAX  
FROM         TXINV LEFT OUTER JOIN
                      TXCOEA ON TXINV.ccno = TXCOEA.ccno
WHERE     (TXINV.CCNO >0) and CCEtax<>cetax and txinv.TYPE<>'A' and txinv.TYPE<>'C'
order by type
