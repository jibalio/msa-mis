SELECT guards.gid, concat(ln,', ',fn,' ',mn) as name,
 concat (streetno,', ',street,', ',brgy,', ', city) as Location

 from msadb.guards 
 left join address on address.gid=guards.gid 
 where gstatus=2;