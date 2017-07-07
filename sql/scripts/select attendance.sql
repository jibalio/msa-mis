select atid, dutydetails.did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (ti_hh,':',ti_mm,' ',ti_period, ' - ',to_hh,':',to_mm,' ',to_period) as Schedule,
                            timein,
                           TimeOut, hours, 
                            night as NightHours, overtime,
                            case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            where month='7' and period = '1' and year = '2017'
                            order by date asc;