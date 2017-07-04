SELECT month, period, year
FROM msadb.attendance 
left join dutydetails
on attendance.did=dutydetails.did 
where AID = 1
group by month,period,year;