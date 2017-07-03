use msadb;
select atid, dutydetails.did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (ti_hh,':',ti_mm,' ',ti_period, ' - ',to_hh,':',to_mm,' ',to_period) as Schedule,
                            case when timein is null then 'Not set' when timein is not null then timein end as TimeIn,
                            case when timeout is null then 'Not set' when timeout is not null then timeout end as TimeOut, hours, 
                            night as NightHours,
                            case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            order by date asc;