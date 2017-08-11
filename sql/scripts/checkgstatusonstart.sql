update
	request_assign 
    left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID 
    left join guards on guards.gid = sduty_assignment.GID
set
	gstatus=1
where
	contractstart<now() AND ContractEnd>now()