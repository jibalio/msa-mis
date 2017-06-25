select name,
 case rstatus
                        when 1 then 'Pending'
                        when 2 then 'Approved'
                        when 3 then 'Active'
                        when 4 then 'Declined'
                        end as status from request_unassign
left join request on request_unassign.RID = request.RID
left join client on request.CID=client.CID
