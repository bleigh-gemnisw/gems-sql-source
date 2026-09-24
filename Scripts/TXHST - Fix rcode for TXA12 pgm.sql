update txhst set rcode='S' from txhst INNER JOIN TXinv ON TXINV.LIST# = TXhst.LIST# and TXINV.TYPE = TXhst.type and TXINV.year = TXhst.year
where icode='S' and rcode<>'S' and txhst.PRF='TXA12' and txinv.SUSDT <= txhst.pdate
