SELECT hid, datestart, dateend, `desc`, 
case type 
when 1 then 'Regular'
when 2 then 'Special'
end as type
FROM msadb.holiday;