SELECT a.avg_user_impact
                                * a.avg_total_user_cost
                                * a.user_seeks,
                                db_name(c.database_id),
                                OBJECT_NAME(c.object_id, c.database_id),
                                c.equality_columns,
                                c.inequality_columns,
                                c.included_columns,
                                c.statement,
                                'USE [' + DB_NAME(c.database_id) + '];
                              CREATE INDEX mrdenny_' + replace(replace(replace(replace
                                (ISNULL(equality_columns, '')
                                + ISNULL(c.inequality_columns, ''), ', ', '_'),
                                '[', ''), ']', ''), ' ', '') + '
                                ON [' + schema_name(d.schema_id) + ']
                                .[' + OBJECT_NAME(c.object_id, c.database_id) + ']
                                (' + ISNULL(equality_columns, '') +
                                CASE WHEN c.equality_columns IS NOT NULL
                                  AND c.inequality_columns IS NOT NULL THEN ', '
                                  ELSE '' END + ISNULL(c.inequality_columns, '') + ')
                                  ' + CASE WHEN included_columns IS NOT NULL THEN
                                  'INCLUDE (' + included_columns + ')' ELSE '' END + '
                                  WITH (FILLFACTOR=70, ONLINE=ON)'
                              FROM sys.dm_db_missing_index_group_stats a
                              JOIN sys.dm_db_missing_index_groups b
                                ON a.group_handle = b.index_group_handle
                              JOIN sys.dm_db_missing_index_details c
                                ON b.index_handle = c.index_handle
                              JOIN sys.objects d ON c.object_id = d.object_id
                              WHERE c.database_id = db_id()
                              ORDER BY DB_NAME(c.database_id),
                                ISNULL(equality_columns, '')
                                + ISNULL(c.inequality_columns, ''), a.avg_user_impact
                                * a.avg_total_user_cost * a.user_seeks DESC