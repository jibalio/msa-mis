USE `msadb`;
DROP procedure IF EXISTS `proc_holiday_remove`;

DELIMITER $$
USE `msadb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_holiday_remove`(IN hid INT(1))
BEGIN
	/*
		Step 1: This procedure removes a holiday (duh?)
        Set status of Holiday CLASS to 0,
        so next years cannot produce any more x holiday.alter
        
        Step 2: Also, deletes the existing INSTANCES 
        ONLY ON THE CURRENT YEAR. As if it never existed.
        
        To re-add holiday, new Holiday Class must be made
        but old instances of X holiday still references the 
        undeleted holiday.
    */
    
    -- STEP 1
    UPDATE `msadb`.`holiday` SET `status`='0' WHERE `hid`=hid;
    
	-- STEP 2
    DELETE FROM `msadb`.`holiday_instance` 
    WHERE 
		`hhid`='1' 
		 AND `DateStart` > CONCAT(YEAR(CURDATE()), '-', '01-01 00:00:00');

    
END$$

DELIMITER ;

