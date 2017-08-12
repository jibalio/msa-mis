	SET @t1 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=1);
    SET @t2 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=2);
    SET @t3 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=3);
    
-- get ONLY the next pending basic pay
            SET @de1 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 1 order by date_effective desc limit 1);
            SET @de1 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 2 order by date_effective desc limit 1);
            SET @de1 = (select date_effective from contribdetails where date_effective < NOW() and `date_dissolved`> NOW() and status = 2 and type = 3 order by date_effective desc limit 1);

	UPDATE msadb.contribdetails
			set `date_dissolved` = (case 
				-- Type 1
					when (status=1 and @t1>1 and type=1) then (@de1)
					
				-- Type 2
					when(status = 1 and @t2 > 1 and type = 2) then(@de2)      
					when(status = 2 and @t2 > 1 and type = 2) then `date_dissolved` 
					when(status = 1 and @t2 = 1 and type = 2) then `date_dissolved`
					when(status = 2 and @t2 = 1 and type = 2) then `date_dissolved` 
                    when(status = 0 and @t1 = 1 and type=2) then `date_dissolved`
            -- Type 3
					when(status = 1 and @t3 > 1 and type = 3) then(@de3)                 
					when(status = 2 and @t3 > 1 and type = 3) then `date_dissolved` 
					when(status = 1 and @t3 = 1 and type = 3) then `date_dissolved`
					when(status = 2 and @t3 = 1 and type = 3) then `date_dissolved`    
                    when(status = 0 and @t3 = 1 and type = 3) then `date_dissolved`     
            end),
			status = (case 	
					when (status=1 and (@t1)>1 and type=1) then 0 
					when (status=2 and (@t1)>1 and type=1) then 1 
					when (status=1 and (@t1)=1 and type=1) then status
					when (status=2 and (@t1)=1 and type=1) then status 
                    
                    when (status=1 and (@t2)>1 and type = 2) then 0 
					when (status=2 and (@t2)>1 and type = 2) then 1 
					when (status=1 and (@t2)=1 and type = 2) then status
					when (status=2 and (@t2)=1 and type = 2) then status 
                    
					when (status=1 and (@t3)>1 and type = 3) then 0 
					when (status=2 and (@t3)>1 and type = 3) then 1 
					when (status=1 and (@t3)=1 and type = 3) then status
					when (status=2 and (@t3)=1 and type = 3) then status 
                    end)
	where date_effective<NOW() and `date_dissolved`>NOW();
    
    
