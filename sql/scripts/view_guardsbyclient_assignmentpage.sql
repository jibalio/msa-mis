select 
guards.gid, dutydetails.did, sduty_assignment.aid,
concat(ln,', ',fn,' ',mn),
concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,
case 
	when concat(timein, timeout, days)  is null then 'Unscheduled'
    else concat(timein, timeout, days) 
    end as schedule
 from guards 
left join sduty_assignment on sduty_assignment.gid=guards.gid
left join dutydetails on sduty_assignment.aid=dutydetails.aid
left join request_assign on request_assign.raid=sduty_assignment.raid; 
