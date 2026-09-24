SELECT list#,year,code,ltr,deyear, COUNT(*) 
FROM txdcdtl
GROUP BY list#,year,code,ltr,deyear
HAVING COUNT(list#) > 1
