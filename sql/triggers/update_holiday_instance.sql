CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_holiday_update`(IN hid INT(11), IN ds varchar(20), IN de varchar(20), IN nm VARCHAR(60), IN typee INT(1), IN trans INT(1))
BEGIN

	-- Edit Class Definition
	UPDATE `msadb`.`holiday` 
    SET 
		`name`= name, 
        `transferability`=trans, 
        `type`=typee
	WHERE `hid`=hid;
	
    /*
    UPDATES date definition in CURRENT YEAR ONLY.
    Any holiday_instance less than current year will stay AS IS.
    */
    UPDATE `msadb`.`holiday_instance` 
    SET 
		`DateStart`='2017-09-12 00:00:010', 
        `DateEnd`='1' 
	WHERE `DateStart` > CONCAT(YEAR(CURDATE()), '-', '01-01 00:00:00');
END