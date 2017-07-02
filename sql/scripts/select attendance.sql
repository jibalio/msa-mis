select atid, did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, hours, 
case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday,
night as NightHours,
case when timein is null then 'Not set' when timein is not null then timein end as TimeIn,
case when timeout is null then 'Not set' when timeout is not null then timeout end as TimeOut
from attendance order by date asc;