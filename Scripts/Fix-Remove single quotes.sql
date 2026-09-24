update VENDOR
set VENNM = replace(replace(replace(VENNM,'''',''),'"',''),',','') ;

update VENDOR
set VSORT = replace(replace(replace(VSORT,'''',''),'"',''),',','') ;

update APEHST
set VENNM = replace(replace(replace(VENNM,'''',''),'"',''),',','') ;

update APEHST
set DSCTX = replace(replace(replace(DSCTX,'''',''),'"',''),',','') ;

update LEDHST
set INVNR = replace(replace(replace(INVNR,'''',''),'"',''),',','') ;

update LEDHST
set TDESC = replace(replace(replace(TDESC,'''',''),'"',''),',','') ;

update LEDGER
set INVNR = replace(replace(replace(INVNR,'''',''),'"',''),',','') ;

update LEDGER
set TDESC = replace(replace(replace(TDESC,'''',''),'"',''),',','') ;

update POMAST
set VENNM = replace(replace(replace(VENNM,'''',''),'"',''),',','') ;
