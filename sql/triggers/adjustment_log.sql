CREATE DEFINER=`root`@`localhost` TRIGGER `msadb`.`payroll_BEFORE_UPDATE` 
BEFORE UPDATE ON `payroll` 
FOR EACH ROW
BEGIN
	IF NEW.cashbond <> OLD.cashbond THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (OLD.pid, 1, NOW(), OLD.cashbond);
        END IF;
	IF NEW.cola <> OLD.cola THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (OLD.pid, 2, NOW(), OLD.cola);
        END IF;
	IF NEW.thirteenth <> OLD.thirteenth THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (OLD.pid, 3, NOW(), OLD.cola); 
        END IF;
	IF NEW.cashadv <> OLD.cashadv THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (OLD.pid, 4, NOW(), OLD.cashadv);	
        END IF;
	IF NEW.cola <> OLD.cola THEN
		INSERT INTO `msadb`.`adjustment_log` (`PID`, `AdjType`, `AdjDate`, `Value`) 
        VALUES (OLD.pid, 5, NOW(), OLD.emergencyallowance);    
    END IF;
END