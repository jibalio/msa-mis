select contrib_id, date_effective, date_dissolved, case status 
when 1 then 'Active'
when 2 then 'Pending'
when 0 then 'Inactive'
end as `status`
from contribdetails