/*
SQL Server Max Memory Myths 
Jes Schultz Borland 
Consultant @ Brent Ozar PLF 
http://brentozar.com  
*/

/* Physical memory. View external pressure. */
SELECT total_physical_memory_kb, 
	total_physical_memory_kb/1024 as total_physical_memory_mb, 
	available_physical_memory_kb, 
	available_physical_memory_kb/1024 as available_physical_memory_mb, 
	system_memory_state_desc
FROM sys.dm_os_sys_memory; 

/* What are max and min memory set to in the SQL Server instance? */
SELECT configuration_id, 
	name, 
	minimum, 
	maximum, 
	value_in_use
FROM master.sys.configurations
WHERE name IN ('min server memory (MB)', 'max server memory (MB)'); 

/* What's swimming in the buffer pool? */
SELECT BD.page_type, 
	BD.database_id, 
	DB.name AS database_name, 
	BD.[file_id], 
	BD.page_id, 
	BD.allocation_unit_id, 
	BD.row_count, 
	BD.is_modified 
FROM sys.dm_os_buffer_descriptors BD
	LEFT JOIN sys.databases DB ON DB.database_id = BD.database_id
ORDER BY BD.page_type;
	
/* What's sunning on the beach? 
   Note to self: switch to Results To Text */
DBCC MEMORYSTATUS
/*
   Memory Manager - overall memory consumption 
   Memory node Id = 0 - Can see multipage vs. singlepage in 2008R2 and below. 
   Buffer Pool 
   Procedure Cache 
  http://support.microsoft.com/kb/907877 
*/

/* CLR */ 
--2008R2 
-- Note to self: switch back to Results To Grid. 
/* SELECT [type], 
	pages_allocated_count, 
	page_size_in_bytes, 
	max_pages_allocated_count
FROM sys.dm_os_memory_objects 
WHERE [type] like '%clr%'; */

--2012
SELECT [type], 
	pages_in_bytes,  
	page_size_in_bytes, 
	max_pages_in_bytes
FROM sys.dm_os_memory_objects 
WHERE [type] like '%clr%';

/* Where is all of my memory going? */
/* Buffer pages allocated to individual databases */ 
--2005/2008/2008R2
/* What is in the cache? */
/* SELECT  [type] ,
        name AS [Description] ,
        CAST(COUNT(pages_allocated_count) * 8 / 1024.0 AS NUMERIC(10, 2)) AS [Memory Utilized in MB] ,
        0 AS [Free Space on Cached Pages MB]
FROM    sys.dm_os_memory_cache_entries
GROUP BY name ,
        [type]
UNION ALL
/* Buffer pages allocated to other memory structures */ 
SELECT  'buffer pool' AS [type] ,
        CASE database_id
          WHEN 32767 THEN 'ResourceDb'
          ELSE DB_NAME(database_id)
        END AS [Description] ,
        CAST(COUNT(*) * 8 / 1024.0 AS NUMERIC(10, 2)) AS [Memory Utilized in MB] ,
        CAST(SUM(CAST(free_space_in_bytes AS BIGINT)) / 1024. / 1024. AS NUMERIC(10,
                                                              2)) AS [Free Space on Cached Pages MB]
FROM    sys.dm_os_buffer_descriptors
GROUP BY DB_NAME(database_id) ,
        database_id
ORDER BY [Memory Utilized in MB] DESC; */

--2012
/* What is in the cache? */
SELECT  type ,
        name AS [Description] ,
        CAST(SUM(pages_kb) / 1024.0 AS NUMERIC(10, 2)) AS [Memory Utilized in MB] ,
        0 AS [Free Space on Cached Pages MB]
FROM    sys.dm_os_memory_cache_entries
GROUP BY name ,
        type
UNION ALL
/* Buffer pages allocated to other memory structures */ 
SELECT  'buffer pool' AS TYPE ,
        CASE database_id
          WHEN 32767 THEN 'ResourceDb'
          ELSE DB_NAME(database_id)
        END AS [Description] ,
        CAST(COUNT(*) * 8 / 1024.0 AS NUMERIC(10, 2)) AS [Memory Utilized in MB] ,
        CAST(SUM(CAST(free_space_in_bytes AS BIGINT)) / 1024. / 1024. AS NUMERIC(10,
                                                              2)) AS [Free Space on Cached Pages MB]
FROM    sys.dm_os_buffer_descriptors
GROUP BY DB_NAME(database_id) ,
        database_id
ORDER BY [Memory Utilized in MB] DESC;
