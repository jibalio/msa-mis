select concat(ln,', ',fn,' ',mn) as name
 from request
left join client on client.cid=request.cid
left join request_assign on request_assign.rid=request.rid
left join sduty_assignment on sduty_assignment.raid=request_assign.raid
left join guards on guards.gid=sduty_assignment.gid
left join period on guards.gid=period.gid
where RequestType = 1 and
((period=1
and month = 7
and year = 2017) OR
(pid is null))
group by guards.gid
