select 
    s.name as SchemaName,
    t.name as TableName,
    tc.name as ColumnName,
    ic.key_ordinal as KeyOrderNr
from 
    sys.schemas s 
    inner join sys.tables t   on s.schema_id=t.schema_id
    inner join sys.indexes i  on t.object_id=i.object_id
    inner join sys.index_columns ic on i.object_id=ic.object_id 
                                   and i.index_id=ic.index_id
    inner join sys.columns tc on ic.object_id=tc.object_id 
                             and ic.column_id=tc.column_id
where i.is_primary_key=1 
order by t.name, ic.key_ordinal ;