select * from attendance 
left join period on period.pid = attendance.pid
left join dutydetails on attendance.did = dutydetails.did
left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
left join guards on guards.gid=sduty_assignment.gid
where guards.gid=306
and period=1 
and year=2017