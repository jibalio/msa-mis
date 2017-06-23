select concat(ln,', ',fn,' ',mn) as name from guards 
                                            left join sduty_assignment on sduty_assignment.GID = guards.gid
                                            left join request_dismiss on request_dismiss.gid = guards.gid
                                            where rid = 2;