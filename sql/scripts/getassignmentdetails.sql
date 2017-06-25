/* return Gid, Name sa Guard, CID, name sa client, status */
select 
guards.gid as gid,
client.cid,
concat(ln,', ',fn,' ',mn) as guardname,
client.name as clientname,
case astatus when 1 then 'Active' when 2 then 'Inactive' end as assignmentstatus
 from sduty_assignment
left join request_assign on sduty_assignment.RAID=request_assign.RAID
left join request on request.RID = request_assign.RID
left join client on request.cid = client.cid
left join guards on guards.gid = sduty_assignment.GID