USE `msadb`;
DROP procedure IF EXISTS `init_checkdate_rates`;

DELIMITER $$
USE `msadb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `init_checkdate_rates`()
BEGIN
	SET @t1 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=1);
    SET @t2 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=2);
    SET @t3 = (select count(*) from contribdetails where date_effective<NOW() and `date_dissolved`>NOW() and type=3);
	UPDATE msadb.contribdetails
	set status = (case 	-- Type 1 - SSS Contrib i think
						when (status=1 and (@t1)>1 and type=1) then 0 
						when (status=2 and (@t1)>1 and type=1) then 1 
                        -- Type 1 - SSS Contrib i think
						when (status=1 and (@t2)>1 and type=2) then 0 
						when (status=2 and (@t2)>1 and type=2) then 1 
                        -- Type 1 - SSS Contrib i think
						when (status=1 and (@t2)>1 and type=3) then 0 
						when (status=2 and (@t2)>1 and type=3) then 1 
                        end)
	where date_effective<NOW() and `date_dissolved`>NOW();
END$$

DELIMITER ;

