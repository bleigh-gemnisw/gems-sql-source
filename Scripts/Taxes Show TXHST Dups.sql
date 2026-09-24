SELECT recid, COUNT(recid) 
FROM txhst
GROUP BY recid
HAVING COUNT(recid) > 1
